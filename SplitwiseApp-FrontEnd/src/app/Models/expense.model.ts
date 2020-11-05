import {Groups} from './groups.model'
import { User } from './user.model';

export interface Expense{
  expenseId :number;
  Description :string;
  Amount :number;
  Currency :string;
  SplitBy :string;
  groupId :number;
  creatorId :string;
  groups? :Groups;
  users? :User;

}
