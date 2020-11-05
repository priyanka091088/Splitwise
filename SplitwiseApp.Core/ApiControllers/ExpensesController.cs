using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Expense;
using System.Threading.Tasks;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Group;

namespace SplitwiseApp.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        #region private variables

        private readonly IExpenses _expenses;
        private readonly IGroups _groups;
        private readonly AppDbContext _context;
        #endregion

        #region constructor
        public ExpensesController(IExpenses expenses, IGroups groups,AppDbContext context)
        {
            _expenses = expenses;
            _groups = groups;
            _context = context;

        }
        #endregion

        #region API controller methods

        // GET: api/Expenses/id
        [HttpGet("{id}")]
        [Route("expense/{id}")]
        public ActionResult<ExpensesDTO> GetExpenseByExpenseId(int id)
        {
            if (_expenses.ExpenseExist(id))
            {
                IEnumerable<ExpensesDTO> expensesDto = _expenses.GetExpensesByexpenseId(id);
                return Ok(expensesDto);
            }
            return NotFound();

        }

        [HttpGet("{groupId}")]
        [Route("groupsExpense/{groupId}")]
        public ActionResult<ExpensesDTO> ExpenseForAGroup(int groupId)
        {
            if (_groups.GroupExist(groupId))
            {
                IEnumerable<ExpensesDTO> expensesDto = _expenses.GetExpenseForGroup(groupId);
                return Ok(expensesDto);
            }
            return NotFound();
        }

        // POST: api/Expenses
        [HttpPost]
        public IActionResult AddExpense(Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var count = _expenses.AddAnExpense(expenses);
            if (count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }

        }

        // PUT: api/Expenses
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(Expenses expenses,int id)
        {
            if (!ModelState.IsValid || !_expenses.ExpenseExist(expenses.expenseId) || !(expenses.expenseId == id))
            {
                return BadRequest();
            }
            var count= _expenses.UpdateAParticularExpense(expenses);
            if (count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
               
         }

        // DELETE: api/Expenses
        [HttpDelete("{expenseId}")]
        public IActionResult DeleteExpense(int expenseId)
        {
            if (!_expenses.ExpenseExist(expenseId))
            {
                return BadRequest();
               
            }
            var count=_expenses.DeleteAnExpense(expenseId);
            
            if (count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
        #endregion
    }
}
