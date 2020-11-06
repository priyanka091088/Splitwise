using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Expense;
using SplitwiseApp.Repository.Payers_Expense;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayersExpensesController: ControllerBase
    {
        #region private variables
        private readonly IPayersExpenses _payersExpense;
        private readonly IExpenses _expenses;
        #endregion

        #region constructor
        public PayersExpensesController(IPayersExpenses payersExpense,IExpenses expenses)
        {
            _payersExpense = payersExpense;
            _expenses = expenses;
        }

        #endregion

        #region API Controller methods

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Payers_ExpensesDTO>> GetPayersExpensesByexpenseId(int id)
        {
            if (_expenses.ExpenseExist(id))
            {
                IEnumerable<Payers_ExpensesDTO> payer = _payersExpense.GetPayersExpensesByExpenseId(id);
                return Ok(payer);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddPayersExpense(Payers_Expenses payers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var count = _payersExpense.AddPayersExpenses(payers);
            if (count == 0)
            {
                return NotFound();

            }
            else
                return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayersExpense(Payers_Expenses payers, int id)
        {
            if (!ModelState.IsValid && !(payers.expenseId == id))
            {
                return BadRequest();
            }
            
            var count = _payersExpense.UpdatePayersExpenses(payers);
            if (count == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{payerId}")]
        public IActionResult DeletePayersExpense(int payerId)
        {
            if (!_payersExpense.PayerExists(payerId))
            {
                return BadRequest();
            }
            var count = _payersExpense.DeletePayersExpenses(payerId);
            if (count == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        #endregion
    }
}
