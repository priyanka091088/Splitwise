import { Expense } from './expense.model';
import { Groups } from './groups.model';
import { User } from './user.model';

export interface Settlement{
  settlemntId :number;
  Amount :number;
  expenseId :number;
  groupId :number;
  payerId :string;
  receiverId :string;
  expenses :Expense;
  groups :Groups;
  payer :User;
  receiver :User;
}
