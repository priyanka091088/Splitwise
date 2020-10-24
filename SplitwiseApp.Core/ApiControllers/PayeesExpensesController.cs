using Microsoft.AspNetCore.Mvc;
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
    class PayeesExpensesController:ControllerBase
    {
        private readonly IPayeeExpenses _payeesExpense;
        private readonly IExpenses _expenses;
        public PayeesExpensesController(IPayeeExpenses payeesExpense,IExpenses expenses)
        {
            _payeesExpense = payeesExpense;
            _expenses = expenses;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Payees_ExpensesDTO>>> GetPayeesExpensesById(int id)
        {
            if (_expenses.ExpenseExist(id))
            {
                IEnumerable<Payees_ExpensesDTO> payeesExpense = await _payeesExpense.GetPayeesExpenses(id);
                return Ok(payeesExpense);
            }
            return NotFound();
        }
    }
}
