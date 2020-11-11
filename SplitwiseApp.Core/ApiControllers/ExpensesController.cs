using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using SplitwiseApp.Repository.DTOs;
using SplitwiseApp.Repository.Expense;
using System.Threading.Tasks;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Group;
using SplitwiseApp.Repository.User;

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
        private readonly IUser _users;
        #endregion

        #region constructor
        public ExpensesController(IExpenses expenses, IGroups groups,AppDbContext context,IUser users)
        {
            _expenses = expenses;
            _groups = groups;
            _context = context;
            _users = users;

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
                return _expenses.GetExpensesByexpenseId(id);
                 
            }
            return BadRequest();

        }

        [HttpGet("{groupId}")]
        [Route("groupsExpense/{groupId}")]
        public ActionResult<IEnumerable<ExpensesDTO>> ExpenseForAGroup(int groupId)
        {
            if (_groups.GroupExist(groupId))
            {
                IEnumerable<ExpensesDTO> expensesDto = _expenses.GetExpenseForGroup(groupId);
                return Ok(expensesDto);
            }
            return NotFound();
        }

        [HttpGet("UserExpense/{userId}")]
        
        public ActionResult<IEnumerable<ExpensesDTO>> ExpenseForAUser(string userId)
        {
            if (_users.UserExists(userId))
            {
                IEnumerable<ExpensesDTO> expensesDto = _expenses.GetExpenseByUserId(userId);
                return Ok(expensesDto);
            }
            
            return NotFound();
        }

        // POST: api/Expenses
        [HttpPost]
        public ActionResult<Expenses> AddExpense(Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return _expenses.AddAnExpense(expenses);

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
