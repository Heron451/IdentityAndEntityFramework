using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityAndEntityFramework.Contexts;
using IdentityAndEntityFramework.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityAndEntityFramework.Controllers
{
    public class EmployeePayrollController : Controller
    {
        private readonly EmployeePayrollContext _context;

        public EmployeePayrollController(EmployeePayrollContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: EmployeePayroll
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblEmployeePayroll.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> Summary()
        {
            return View(await _context.tblEmployeePayroll.ToListAsync());
        }
        [Authorize]
        // GET: EmployeePayroll/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePayrollModel = await _context.tblEmployeePayroll
                .FirstOrDefaultAsync(m => m.employeeId == id);
            if (employeePayrollModel == null)
            {
                return NotFound();
            }

            return View(employeePayrollModel);
        }
        [Authorize]
        // GET: EmployeePayroll/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: EmployeePayroll/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("employeeId,FirstName,LastName,Address,PhoneNumber,Wage,HoursWorked")] EmployeePayrollModel employeePayrollModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeePayrollModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeePayrollModel);
        }
        [Authorize]
        // GET: EmployeePayroll/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePayrollModel = await _context.tblEmployeePayroll.FindAsync(id);
            if (employeePayrollModel == null)
            {
                return NotFound();
            }
            return View(employeePayrollModel);
        }
        [Authorize]
        // POST: EmployeePayroll/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("employeeId,FirstName,LastName,Address,PhoneNumber,Wage,HoursWorked")] EmployeePayrollModel employeePayrollModel)
        {
            if (id != employeePayrollModel.employeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePayrollModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePayrollModelExists(employeePayrollModel.employeeId))
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
            return View(employeePayrollModel);
        }
        [Authorize]
        // GET: EmployeePayroll/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePayrollModel = await _context.tblEmployeePayroll
                .FirstOrDefaultAsync(m => m.employeeId == id);
            if (employeePayrollModel == null)
            {
                return NotFound();
            }

            return View(employeePayrollModel);
        }
        [Authorize]
        // POST: EmployeePayroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeePayrollModel = await _context.tblEmployeePayroll.FindAsync(id);
            _context.tblEmployeePayroll.Remove(employeePayrollModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePayrollModelExists(int id)
        {
            return _context.tblEmployeePayroll.Any(e => e.employeeId == id);
        }
    }
}
