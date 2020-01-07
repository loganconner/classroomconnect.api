using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassroomConnect.Api.ViewModels;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomConnect.Api.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public ValuesController(ILoggerManager logger, IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
            _mapper = mapper;
        }

        #region Address

        [HttpGet]
        [Route("GetAddress/{addressId}")]
        public IActionResult GetAddress(string addressId)
        {
            if (addressId == null)
            {
                return BadRequest("Missing parameter for AddressId.");
            }
            try
            {
                Guid guid = new Guid(addressId);

                var address = _repoWrapper.Address.FindByCondition(i => i.AddressId == guid && !i.IsDeleted).FirstOrDefault();

                var addressVM = _mapper.Map<AddressViewModel>(address);

                return Ok(addressVM);
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    _logger.LogError($"Address with id: {addressId}, hasn't been found in db.");
                    return NotFound();
                }
                _logger.LogError($"Something went wrong inside GetAddress action: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAddresses/{personId}")]
        public IActionResult GetAddresses(string personId)
        {
            List<AddressViewModel> addressList = new List<AddressViewModel>();
            try
            {
                var g = new Guid(personId);
                var personAddresses = _repoWrapper.PersonAddress.FindByCondition(i => i.PersonId == g).ToList();
                if (personAddresses.Count > 0)
                {
                    foreach (var a in personAddresses)
                    {
                        var address = _repoWrapper.Address.FindByCondition(i => i.AddressId == a.AddressId && !i.IsDeleted).FirstOrDefault();

                        addressList.Add(_mapper.Map<AddressViewModel>(address));
                    }
                    return Ok(addressList);
                }
                else
                {
                    _logger.LogInfo($"No address found for personId {personId}.");
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading address list for personId {personId}. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("CreateAddress/{personid}")]
        public IActionResult CreateAddress([FromBody]AddressViewModel addressVM, string personId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Address address = Helpers.EntitiyMappingManager.MapAddressToBO(addressVM);

                    _repoWrapper.Address.Create(address);

                    var personIdGuid = new Guid(personId);

                    PersonAddress personAddress = new PersonAddress() { AddressId = address.AddressId, PersonId = personIdGuid };

                    _repoWrapper.PersonAddress.Create(personAddress);

                    _repoWrapper.Save();

                    AddressViewModel addrVM = _mapper.Map<AddressViewModel>(address);
                    if (!addrVM.AddressId.Equals(Guid.Empty))
                    {
                        return CreatedAtAction("CreateAddress", addrVM.AddressId, addrVM);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {

                    _logger.LogError($"Something went wrong inside CreateAddress action: {ex.Message}");
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateAddress")]
        public IActionResult UpdateAddress([FromBody]AddressViewModel addressVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Address address = Helpers.EntitiyMappingManager.MapAddressToBO(addressVM);

                    _repoWrapper.Address.Update(address);
                    _repoWrapper.Save();


                    return Ok(addressVM);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        _logger.LogError($"Address with id: {addressVM.AddressId}, hasn't been found in db.");
                        return NotFound();
                    }
                    _logger.LogError($"Something went wrong inside UpdateAddress action: {ex.Message}");
                    return BadRequest();
                }
            }
            _logger.LogError($"Invalid Model for UpdateAddress action.");
            return BadRequest();
        }

        [HttpPut]
        [Route("DeleteAddress/{addressId}")]
        public IActionResult DeleteAddress(string addressId)
        {

            if (addressId == null)
            {
                return BadRequest("Missing parameter for AddressId.");
            }

            try
            {
                var addGuid = new Guid(addressId);

                Address address = _repoWrapper.Address.FindByCondition(i => i.AddressId == addGuid).FirstOrDefault();

                address.IsDeleted = true;

                _repoWrapper.Address.Update(address);
                _repoWrapper.Save();

                var addressVM = _mapper.Map<AddressViewModel>(address);

                return Ok(addressVM);
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    _logger.LogError($"Address with id: {addressId}, hasn't been found in db.");
                    return NotFound();
                }
                _logger.LogError($"Something went wrong inside DeleteAddress action: {ex.Message}");
                return BadRequest();
            }
        }
        #endregion

        #region Child

        [HttpPost]
        [Route("CreateChild")]
        public IActionResult CreateChild([FromBody]ChildViewModel child)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    Child childBO = Helpers.EntitiyMappingManager.MapChildToBO(child);

                    _repoWrapper.Child.Create(childBO);

                    _logger.LogInfo($"Created record for Child: {childBO.ChildId}");                  

                    _repoWrapper.Save();

                    return CreatedAtAction("CreateChild", childBO.ChildId, childBO);
                }
                catch (Exception ex)
                {

                    _logger.LogError($"Something went wrong inside CreateGuardian action: {ex.Message}");
                    return BadRequest();
                }

            }

            return BadRequest();
        }


        [HttpGet]
        [Route("GetChild/{childId}")]
        public IActionResult GetChild(string childId)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var guid = new Guid(childId);

                    ChildViewModel childVM = null;

                    var child = _repoWrapper.Child.GetChildWithDetails(guid);

                    if (child != null)
                    {
                        childVM = (_mapper.Map<ChildViewModel>(child));

                        return Ok(childVM);
                    }
                    else
                    {
                        _logger.LogInfo($"Unable to locate child id {childId}.");

                        return NoContent();
                    }

                }
                catch (Exception ex)
                {

                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        _logger.LogError($"Child with id: {childId}, hasn't been found in db.");
                        return NotFound();
                    }
                    _logger.LogError($"Something went wrong inside GetGuardian action: {ex.Message}");
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateChild")]
        public IActionResult UpdateChild([FromBody]ChildViewModel childVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Child child = Helpers.EntitiyMappingManager.MapChildToBO(childVM);

                    _repoWrapper.Child.Update(child);
                                     
                    _repoWrapper.Save();


                    return Ok(childVM);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        _logger.LogError($"Child with id: {childVM.ChildId}, hasn't been found in db.");
                        return NotFound();
                    }
                    _logger.LogError($"Something went wrong inside UpdateChild action: {ex.Message}");
                    return BadRequest();
                }
            }
            _logger.LogError($"Invalid Model for UpdateChild action.");
            return BadRequest();
        }

        #endregion

        #region Classroom

        [HttpGet]
        [Route("GetClassrooms")]
        public IActionResult GetClassrooms()
        {
            try
            {
                List<ClassroomViewModel> classroomVM = new List<ClassroomViewModel>();

                List<Classroom> classrooms = _repoWrapper.Classroom.FindAll().ToList();

                if (classrooms != null)
                {
                    foreach (var c in classrooms)
                        classroomVM.Add(_mapper.Map<ClassroomViewModel>(c));
                }
                else
                {
                    _logger.LogError($"Unable to load classrooms.");
                    return NotFound();
                }

                return Ok(classroomVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading classrooms. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetClassroomDetails/{classroomId}")]
        public IActionResult GetClassroomDetails(string classroomId)
        {
            try
            {
                Guid guid = new Guid(classroomId);

                ClassroomViewModel classroomVM = new ClassroomViewModel();

                var classroom = _repoWrapper.Classroom.GetClassroomWithDetails(guid);

                if (classroom != null)
                {
                    classroomVM.ClassroomId = classroom.ClassroomId;
                    classroomVM.TeacherName = classroom.TeacherName;
                    classroomVM.ClassDate = classroom.ClassDate;

                    foreach (var child in classroom.Students)
                    {
                        var guardians = _repoWrapper.Guardian.FindByCondition(i => i.FamilyId == child.FamilyId).ToList();
                        var primGuard = guardians.Where(i => i.IsPrimaryGuardian).FirstOrDefault();
                        var secGuard = guardians.Where(i => !i.IsPrimaryGuardian).FirstOrDefault();
                        var studentVM = _mapper.Map<StudentViewModel>(child);

                        studentVM.PrimaryGuardianId = primGuard.GuardianId;
                        studentVM.PrimaryGuardianName = $"{primGuard.FirstName} { primGuard.LastName}";
                        studentVM.SecondaryGuardianId = secGuard.GuardianId;
                        studentVM.SecondaryGuardianName = $"{secGuard.FirstName} { secGuard.LastName}";

                        classroomVM.Students.Add(studentVM);
                    }
                }
                else
                {
                    _logger.LogError($"Unable to load students for classroom id: {classroomId}.");
                    return NotFound();
                }

                return Ok(classroomVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading student list for classroom {classroomId}. Exception: {ex.Message}");
                return BadRequest();
            }
        }

        #endregion

        #region Contact

        [HttpPut]
        [Route("UpdateContacts")]
        public IActionResult UpdateContacts([FromBody]List<ContactViewModel> contacts)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach(var c in contacts)
                    {
                        Contact contact = Helpers.EntitiyMappingManager.MapContactToBO(c);
  
                        Phone phone = Helpers.EntitiyMappingManager.MapPhoneToBO(c.Phone);

                        if (phone.PhoneId == Guid.Empty)
                        {
                            _repoWrapper.Phone.Create(phone);
                            c.PhoneId = phone.PhoneId;
                        }
                        else
                        {
                            _repoWrapper.Phone.Update(phone);
                        }
 
                        Address address = Helpers.EntitiyMappingManager.MapAddressToBO(c.Address);

                        if (address.AddressId == Guid.Empty)
                        {
                            _repoWrapper.Address.Create(address);
                            c.AddressId = address.AddressId;
                        }
                        else
                        {
                            _repoWrapper.Address.Update(address);
                        }

                        if (contact.ContactId == Guid.Empty)
                        {
                            _repoWrapper.Contact.Create(contact);
                        }
                        else
                        {
                            _repoWrapper.Contact.Update(contact);
                        }                        
                    }

                    _repoWrapper.Save();


                    return Ok(contacts);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        _logger.LogError($"Contact for family Id {contacts[0].FamilyId}, hasn't been found in db.");
                        return NotFound();
                    }
                    _logger.LogError($"Something went wrong inside UpdateContact action: {ex.Message}");
                    return BadRequest();
                }
            }
            _logger.LogError($"Invalid Model for UpdateContact action.");
            return BadRequest();
        }

        #endregion

        #region EnrollmentRecord

        [HttpGet]
        [Route("GetEnrollmentRecord/{childId}")]
        public IActionResult GetEnrollmentRecord(string childId)
        {
            if (childId == null)
            {
                return BadRequest("Missing parameter for FamilyId.");
            }
            try
            {
                Guid guid = new Guid(childId);

                EnrollmentRecord er = new EnrollmentRecord();

                var child = _repoWrapper.Child.GetChildWithDetails(guid);

                if (child != null)
                {
                    er.Child = _mapper.Map<ChildViewModel>(child); 
                }
                else
                {
                    _logger.LogError($"Child with id: {childId}, hasn't been found in db.");
                    return NotFound();
                }

                var guardians = _repoWrapper.Guardian.GetChildGuardiansWithDetails(child.FamilyId);

                var primGuardian = guardians.Where(i => i.IsPrimaryGuardian).FirstOrDefault();
                var secGuardian = guardians.Where(i => !i.IsPrimaryGuardian).FirstOrDefault();

                er.PrimaryGuardian = _mapper.Map<GuardianViewModel>(primGuardian);
                er.SecondaryGuardian = _mapper.Map<GuardianViewModel>(secGuardian);

                var contacts = _repoWrapper.Contact.GetChildContactsWithDetails(child.FamilyId);

                foreach(var c in contacts)
                {
                    er.ContactList.Add(_mapper.Map<ContactViewModel>(c));
                }
                

                return Ok(er);
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    _logger.LogError($"Child with id: {childId}, hasn't been found in db.");
                    return NotFound();
                }
                _logger.LogError($"Something went wrong inside GetFamilyDetail action: {ex.Message}");
                return BadRequest();
            }
        }

        #endregion

        #region Family

        [HttpGet]
        [Route("GetFamilyDetail/{familyId}")]
        public IActionResult GetFamilyDetail(string familyId)
        {
            if (familyId == null)
            {
                return BadRequest("Missing parameter for FamilyId.");
            }
            try
            {
                Guid guid = new Guid(familyId);

                FamilyDetailViewModel familyDetailVM = null;

                var familyDetail = _repoWrapper.Family.GetFamilyWithDetails(guid);

                if (familyDetail != null)
                {
                    familyDetailVM = _mapper.Map<FamilyDetailViewModel>(familyDetail);
                }
                else
                {
                    _logger.LogError($"Family with id: {familyId}, hasn't been found in db.");
                    return NotFound();
                }

                return Ok(familyDetailVM);
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    _logger.LogError($"Family with id: {familyId}, hasn't been found in db.");
                    return NotFound();
                }
                _logger.LogError($"Something went wrong inside GetFamilyDetail action: {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("CreateFamily")]
        public IActionResult CreateFamily()
        {
            try
            {
                Family newFamily = new Family() { EntryDate = DateTime.Now };

                _repoWrapper.Family.Create(newFamily);

                _repoWrapper.Save();

                if (!newFamily.FamilyId.Equals(Guid.Empty))
                {
                    return CreatedAtAction("CreateFamily", newFamily.FamilyId);
                }
                else
                {
                    _logger.LogError("Unable to create family record.");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside AddAddress action: {ex.Message}");
                return BadRequest();
            }
        }


        //This deletes a newly created Family record if Guardians are never added.
        [HttpDelete]
        [Route("DeleteNewFamily/{familyId}")]
        public IActionResult DeleteNewFamily(string familyId)
        {
            try
            {
                var guid = new Guid(familyId);

                var family = _repoWrapper.Family.FindByCondition(i => i.FamilyId == guid).FirstOrDefault();

                var guardians = _repoWrapper.Guardian.FindByCondition(i => i.FamilyId == guid).ToList();

                if (guardians == null || guardians.Count < 1 || guardians.FindIndex(i => !i.IsDeleted) < 0)
                {
                    _repoWrapper.Family.Delete(family);

                    _repoWrapper.Save();

                    return Ok($"Successfully deleted record for familyId: {familyId}");
                }
                else
                {
                    _logger.LogWarn($"Guardian records exist for familyId: {familyId}. Unable to delete record.");
                    return BadRequest("Existing Guardians");
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    _logger.LogError($"Family with id: {familyId}, hasn't been found in db.");
                    return NotFound();
                }
                _logger.LogError($"Something went wrong inside DeleteFamily action: {ex.Message}");
                return BadRequest();
            }
        }

        #endregion

        #region Guardian

        [HttpPost]
        [Route("CreateGuardian")]
        public IActionResult CreateGuardian([FromBody]GuardianViewModel guardian)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    Guardian guardianBO = Helpers.EntitiyMappingManager.MapGuardianToBO(guardian);

                    //Mobile phone  
                    Phone mobilePhone = Helpers.EntitiyMappingManager.MapPhoneToBO(guardian.MobilePhone);

                    _repoWrapper.Phone.Create(mobilePhone);
                    guardianBO.MobilePhoneId = mobilePhone.PhoneId;

                    //Work phone  
                    Phone workPhone = Helpers.EntitiyMappingManager.MapPhoneToBO(guardian.WorkPhone);

                    _repoWrapper.Phone.Create(workPhone);
                    guardianBO.WorkPhoneId = workPhone.PhoneId;

                    //Home address  
                    Address homeAddress = Helpers.EntitiyMappingManager.MapAddressToBO(guardian.HomeAddress);

                    _repoWrapper.Address.Create(homeAddress);
                    guardianBO.HomeAddressId = homeAddress.AddressId;

                    //Work address  
                    Address workAddress = Helpers.EntitiyMappingManager.MapAddressToBO(guardian.WorkAddress);

                    _repoWrapper.Address.Create(workAddress);
                    guardianBO.WorkAddressId = workAddress.AddressId;

                    _repoWrapper.Guardian.Create(guardianBO);

                    _logger.LogInfo($"Created record for Guardian: {guardianBO.GuardianId}");                   

                    _repoWrapper.Save();

                    return CreatedAtAction("CreateGuardian", guardianBO.GuardianId, guardianBO);
                }
                catch (Exception ex)
                {

                    _logger.LogError($"Something went wrong inside CreateGuardian action: {ex.Message}");
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetGuardian/{guardianId}")]
        public IActionResult GetGuardian(string guardianId)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var guid = new Guid(guardianId);

                    GuardianViewModel guardianVM = null;

                    var guardian = _repoWrapper.Guardian.GetGuardianWithDetails(guid);

                    if (guardian != null )
                    {
                        guardianVM = (_mapper.Map<GuardianViewModel>(guardian));

                        return Ok(guardianVM);
                    }
                    else
                    {
                        _logger.LogInfo($"Unable to locate guardian id {guardianId}.");

                        return NoContent();
                    }

                }
                catch (Exception ex)
                {

                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        _logger.LogError($"Guardian with id: {guardianId}, hasn't been found in db.");
                        return NotFound();
                    }
                    _logger.LogError($"Something went wrong inside GetGuardian action: {ex.Message}");
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpGet]
        [Route("SearchGuardian/{searchTerm}")]
        public IActionResult SearchGuardian(string searchTerm)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    List<GuardianViewModel> guardians = new List<GuardianViewModel>();

                    var guardianList = _repoWrapper.Guardian.FindByCondition(g => g.FirstName.Contains(searchTerm) || g.LastName.Contains(searchTerm)).OrderBy(g => g.FamilyId).ToList();

                    if(guardianList != null && guardianList.Count > 0)
                    {
                        foreach(var g in guardianList)
                        {
                            guardians.Add(_mapper.Map<GuardianViewModel>(g));
                        }

                        _logger.LogInfo($"Found {guardianList.Count()} guardians with search term: {searchTerm}");

                        return Ok(guardians);
                    }
                    else
                    {
                        _logger.LogInfo($"Found {guardianList.Count()} guardians with search term: {searchTerm}");

                        return NoContent();
                    }
                    
                }
                catch (Exception ex)
                {

                    _logger.LogError($"Something went wrong inside CreateGuardian action: {ex.Message}");
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateGuardian")]
        public IActionResult UpdateGuardian([FromBody]GuardianViewModel guardian)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Guardian guardianBO = Helpers.EntitiyMappingManager.MapGuardianToBO(guardian);

                    //Mobile phone  
                    Phone mobilePhone = Helpers.EntitiyMappingManager.MapPhoneToBO(guardian.MobilePhone);

                    if(mobilePhone.PhoneId == Guid.Empty)
                    {
                        _repoWrapper.Phone.Create(mobilePhone);
                        guardianBO.MobilePhoneId = mobilePhone.PhoneId;
                    }
                    else
                    {
                        _repoWrapper.Phone.Update(mobilePhone);
                    }
                    
                    //Work phone  
                    Phone workPhone = Helpers.EntitiyMappingManager.MapPhoneToBO(guardian.WorkPhone);

                    if (workPhone.PhoneId == Guid.Empty)
                    {
                        _repoWrapper.Phone.Create(workPhone);
                        guardianBO.WorkPhoneId = workPhone.PhoneId;
                    }
                    else
                    {
                        _repoWrapper.Phone.Update(workPhone);
                    }

                    //Home address  
                    Address homeAddress = Helpers.EntitiyMappingManager.MapAddressToBO(guardian.HomeAddress);

                    if (homeAddress.AddressId == Guid.Empty)
                    {
                        _repoWrapper.Address.Create(homeAddress);
                        guardianBO.HomeAddressId = homeAddress.AddressId;
                    }
                    else
                    {
                        _repoWrapper.Address.Update(homeAddress);
                    }

                    //Work address  
                    Address workAddress = Helpers.EntitiyMappingManager.MapAddressToBO(guardian.WorkAddress);

                    if (workAddress.AddressId == Guid.Empty)
                    {
                        _repoWrapper.Address.Create(workAddress);
                        guardianBO.WorkAddressId = workAddress.AddressId;
                    }
                    else
                    {
                        _repoWrapper.Address.Update(workAddress);
                    }

                    _repoWrapper.Guardian.Update(guardianBO);

                    _repoWrapper.Save();

                    return Ok(guardianBO);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        _logger.LogError($"Guardian with id: {guardian.GuardianId}, hasn't been found in db.");
                        return NotFound();
                    }
                    _logger.LogError($"Something went wrong inside UpdateGuardian action: {ex.Message}");
                    return BadRequest();
                }
            }
            _logger.LogError($"Invalid Model for UpdateChild action.");
            return BadRequest();
        }

        #endregion


    }
}