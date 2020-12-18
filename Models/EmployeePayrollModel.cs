/**************************************************************
* Author: Robin Alexander Hammond
* Date: December 18, 2020
* File Name: PayrollModel.cs
* *************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Added Libraries
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityAndEntityFramework.Models
{
	public class EmployeePayrollModel
	{

		//Variables
		internal double employeePay;
		internal double employeeHours;
		internal double salary;
		internal bool isValid = true;

		// CONSTANTS
		internal const double WEEKS_IN_A_YEAR = 52;

		/// <summary>
		/// EmployeePayroll Constructor 
		/// </summary>
		/// <param name="firstName"> employee first name</param>
		/// <param name="lastName"> employee last name</param>
		/// <param name="address"> employee address</param>
		/// <param name="phoneNumber">employee address</param>
		/// <param name="wage"> employee wage</param>
		/// <param name="hoursWorked"> employee hours worked</param>
		public EmployeePayrollModel(string firstName, string lastName, string address, string phoneNumber, double wage, double hoursWorked)
		{
			FirstName = firstName;
			LastName = lastName;
			Address = address;
			PhoneNumber = phoneNumber;
			Wage = wage;
			HoursWorked = hoursWorked;
		}

		// Default constructor
		public EmployeePayrollModel()
		{

		}

		// Properties

		//Gets and sets an Employee ID for database purposes
		[Key]
		[Display(Name = "Emplyee ID")]
		public int employeeId { get; set; }

		// First Name
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Employee must have a First Name")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		// Last Name
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Employee must have a Last Name")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		// Address
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Employee must have an Adress")]
		[Display(Name = "Address")]
		public string Address { get; set; }
		//Phone Number
		[Display(Name = "Phone Number")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Employee must have a Last Name")]
		public string PhoneNumber { get; set; }
		// hourly wage
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Employee must have a hourly wage")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		 [Display(Name = "Hourly Wage")]
		public double Wage { get; set; }
		// hours worked
		[Required(AllowEmptyStrings = false, ErrorMessage = "You must enter the Hours Worked")]
		[Range(typeof(double), "1", "100", ErrorMessage = "Employee can't work more than 100 hours a week")]
		[Display(Name = "Hours Worked")]
		public double HoursWorked { get; set; }

		/// <summary>
		/// getSalaray Function
		/// </summary>
		public virtual double getSalary(double hoursWorked, double wage)
		{
			
			if (isValid)
			{

				salary = (hoursWorked * wage) * WEEKS_IN_A_YEAR;

			}

			return salary;

		}

	}
}
