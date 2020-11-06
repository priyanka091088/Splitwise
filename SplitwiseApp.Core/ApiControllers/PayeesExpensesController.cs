using Microsoft.AspNetCore.Mvc;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Expense;
using SplitwiseApp.Repository.Payees_Expense;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayeesExpensesController:ControllerBase
    {
        #region private variabes
        private readonly IPayeeExpenses _payeesExpense;
        private readonly IExpenses _expenses;
        #endregion

        #region constructor
        public PayeesExpensesController(IPayeeExpenses payeesExpense,IExpenses expenses)
        {
            _payeesExpense = payeesExpense;
            _expenses = expenses;
        }

        #endregion

        #region API controller methods

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Payees_ExpensesDTO>> GetPayeesExpensesById(int id)
        {
            if (_expenses.ExpenseExist(id))
            {
                IEnumerable<Payees_ExpensesDTO> payeesExpense = _payeesExpense.GetPayeesExpensesByExpenseId(id);
                return Ok(payeesExpense);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddPayeesExpense(Payees_Expenses payees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var count = _payeesExpense.AddPayeesExpenses(payees);

            if (count == 0)
            {
                return NotFound();

            }
            else
                return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayee(Payees_Expenses payees, int id)
        {
            if (!ModelState.IsValid && !(payees.expenseId == id))
            {
                return BadRequest();
            }

            var count = _payeesExpense.UpdatePayeesExpenses(payees);

            if (count == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{payeeId}")]
        public IActionResult DeletePayee(int payeeId)
        {
            if (!_payeesExpense.PayeeExists(payeeId))
            {
                return BadRequest();
            }
            var count = _payeesExpense.DeletePayeesExpenses(payeeId);

            if (count == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        #endregion
    }
}
