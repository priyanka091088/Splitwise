using Microsoft.AspNetCore.Mvc;
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
    class PayersExpensesController: ControllerBase
    {
        private readonly IPayersExpenses _payersExpense;
        private readonly IExpenses _expenses;
        public PayersExpensesController(IPayersExpenses payersExpense,IExpenses expenses)
        {
            _payersExpense = payersExpense;
            _expenses = expenses;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Payers_ExpensesDTO>>> GetPayersExpensesById(int id)
        {
            if (_expenses.ExpenseExist(id))
            {
                IEnumerable<Payers_ExpensesDTO> groupUser = await _payersExpense.GetPayersExpenses(id);
                return Ok(groupUser);
            }
            return NotFound();
        }
    }
}
