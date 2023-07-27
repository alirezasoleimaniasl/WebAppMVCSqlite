using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LineList.Data;
using LineList.Models;
using WebAppMVCSqlite.Areas.Admin.Models.ViewModels;
using BookShop.Classes;

namespace WebAppMVCSqlite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DboPatientsController : Controller
    {
        private readonly LineListContext _context;
        private readonly IConvertDate _convertDate;

        public DboPatientsController(LineListContext context, IConvertDate convertDate)
        {
            _context = context;
            _convertDate = convertDate;
        }

        // GET: Admin/DboPatients
        public async Task<IActionResult> Index()
        {
            var lineListContext = _context.DboPatients.Include(d => d.Address)/*.Include(d => d.Hospital)*//*.Include(d => d.Lab)*/.Include(d => d.PatientStatus)/*.Include(d => d.Vaccine)*/;
            return View(await lineListContext.ToListAsync());
        }

        // GET: Admin/DboPatients/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.DboPatients == null)
            {
                return NotFound();
            }

            var dboPatient = await _context.DboPatients
                .Include(d => d.Address)
                //.Include(d => d.Hospital)
                //.Include(d => d.Lab)
                .Include(d => d.PatientStatus)
                //.Include(d => d.Vaccine)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (dboPatient == null)
            {
                return NotFound();
            }

            return View(dboPatient);
        }

        // GET: Admin/DboPatients/Create
        public IActionResult Create()
        {
            ViewBag.CityId = new SelectList(_context.DboCities, "CityId", "City");
            ViewBag.HospitalId = new SelectList(_context.DboHospitals, "HospitalId", "Name");
            ViewBag.LabId  = new SelectList(_context.DboLabSources, "LabSourceId", "LabName");
            ViewBag.HospitalSection = new SelectList(_context.DboHospitalSections,"HospitalSectionID");
            ViewBag.VaccineId = new SelectList(_context.DboVaccineSources, "VaccineId", "Type");
            return View();
        }

        // POST: Admin/DboPatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientCreateEditViewModel ViewModel)
        {
            try
            {
                DboPatientStatus _patientStatus = new DboPatientStatus()
                {

                };

                DboPatient _patient = new DboPatient()
                {
                    FirstName = ViewModel.FirstName,
                    LastName = ViewModel.LastName,
                    NationalCode = ViewModel.NationalCode,
                    DateOfBirth = ViewModel.DateOfBirth != null ? _convertDate.ConvertShamsiToMiladi(ViewModel.DateOfBirth).ToString() : "",
                    Gender = ViewModel.Gender,
                    Job= ViewModel.Job,
                    FatherName = ViewModel.FatherName, 
                };
            }
            catch
            {

            }
            ViewBag.CityId = new SelectList(_context.DboCities, "CityId", "City");
            ViewBag.HospitalId = new SelectList(_context.DboHospitals, "HospitalId", "Name");
            ViewBag.LabId = new SelectList(_context.DboLabSources, "LabSourceId", "LabName");
            ViewBag.VaccineId = new SelectList(_context.DboVaccineSources, "VaccineId", "Type");
            if (ViewModel.firstVaccineId != null)
            {
                ViewBag.VaccineVisible = "d-block";
                ViewBag.VaccineChecked = "checked";
            }
            else
            {
                ViewBag.VaccineVisible = "d-none";
                ViewBag.VaccineChecked = "";
            }
            if(ViewModel.Gender == "1")
            {
                ViewBag.IsPregnantVisible = "d-none";
            }
            else
            {
                ViewBag.IsPregnantVisible = "d-block";
            }
            if(ViewModel.UnderlyingDiseas == true)
            {
                ViewBag.UderLyingDiseasVisible = "d-block";
            }
            else
            {
                ViewBag.UderLyingDiseasVisible = "d-none";
            }
                
            return View(ViewModel);
        }

        // GET: Admin/DboPatients/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.DboPatients == null)
            {
                return NotFound();
            }

            var dboPatient = await _context.DboPatients.FindAsync(id);
            if (dboPatient == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.DboAddresses, "AddressId", "AddressId", dboPatient.AddressId);
            //ViewData["HospitalId"] = new SelectList(_context.DboHospitals, "HospitalId", "HospitalId", dboPatient.HospitalId);
            //ViewData["LabId"] = new SelectList(_context.DboLaboratories, "LabId", "LabId", dboPatient.LabId);
            ViewData["PatientStatusId"] = new SelectList(_context.DboPatientStatuses, "PatientStatusId", "PatientStatusId", dboPatient.PatientStatusId);
            //ViewData["VaccineId"] = new SelectList(_context.DboVaccines, "VaccineId", "VaccineId", dboPatient.VaccineId);
            return View(dboPatient);
        }

        // POST: Admin/DboPatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PatientId,FirstName,LastName,NationalCode,DateOfBirth,Gender,Job,FatherName,PatientStatusId,VaccineId,LabId,AddressId,HospitalId")] DboPatient dboPatient)
        {
            if (id != dboPatient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dboPatient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DboPatientExists(dboPatient.PatientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.DboAddresses, "AddressId", "AddressId", dboPatient.AddressId);
            //ViewData["HospitalId"] = new SelectList(_context.DboHospitals, "HospitalId", "HospitalId", dboPatient.HospitalId);
            //ViewData["LabId"] = new SelectList(_context.DboLaboratories, "LabId", "LabId", dboPatient.LabId);
            ViewData["PatientStatusId"] = new SelectList(_context.DboPatientStatuses, "PatientStatusId", "PatientStatusId", dboPatient.PatientStatusId);
            //ViewData["VaccineId"] = new SelectList(_context.DboVaccines, "VaccineId", "VaccineId", dboPatient.VaccineId);
            return View(dboPatient);
        }

        // GET: Admin/DboPatients/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.DboPatients == null)
            {
                return NotFound();
            }

            var dboPatient = await _context.DboPatients
                .Include(d => d.Address)
                //.Include(d => d.Hospital)
                //.Include(d => d.Lab)
                .Include(d => d.PatientStatus)
                //.Include(d => d.Vaccine)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (dboPatient == null)
            {
                return NotFound();
            }

            return View(dboPatient);
        }

        // POST: Admin/DboPatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.DboPatients == null)
            {
                return Problem("Entity set 'LineListContext.DboPatients'  is null.");
            }
            var dboPatient = await _context.DboPatients.FindAsync(id);
            if (dboPatient != null)
            {
                _context.DboPatients.Remove(dboPatient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DboPatientExists(long id)
        {
          return (_context.DboPatients?.Any(e => e.PatientId == id)).GetValueOrDefault();
        }
    }
}
