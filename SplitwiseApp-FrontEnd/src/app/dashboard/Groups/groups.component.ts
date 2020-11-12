import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {
  groupDto:services.GroupsDTO;
  groupDtoDetails:services.GroupsDTO[];
  groupDtoList:services.GroupsDTO[]=[];

  memberDto:services.GroupMembersDTO;
  memberDtoDetails:services.GroupMembersDTO[];

  expensesDto:services.ExpensesDTO;
  expensesDtoDetails:services.ExpensesDTO[];
  expensesDtoList:services.ExpensesDTO[]=[];

  payersExpensesDto:services.Payers_ExpensesDTO;
  payersExpensesDetails:services.Payers_ExpensesDTO[];

  payeesExpensesDto:services.Payees_ExpensesDTO;
  payeesExpensesDetails:services.Payees_ExpensesDTO[];

  settlementDto:services.SettlementDTO;
  settlementDtoDetails:services.SettlementDTO[];

public pageTitle:string;
GroupId:number;
check:boolean=false;
arr:number[]=[];
  constructor(private route:ActivatedRoute,private groupsServices:services.GroupsClient,
    private expenseServices:services.ExpensesClient,private payeeServices:services.PayeesExpensesClient,
    private payerServices:services.PayersExpensesClient,private router:Router,private settlementServices:services.SettlementClient) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
    this.GroupId=id;

    this.groupsServices.getGroup2(id).subscribe({
      next:groupDto=>{
        console.log(groupDto);
        this.pageTitle=groupDto.groupName;
        console.log(this.pageTitle);

      }
    });
    this.groupsServices.getGroupBalanceById(id).subscribe({
      next:res=>{
        console.log(res);
        this.memberDtoDetails=res;
      }
    });

    this.expenseServices.expenseForAGroup(id).subscribe({
      next:expenseDto=>{
        console.log(expenseDto);
        this.expensesDtoDetails=expenseDto;
        if(this.expensesDtoDetails.length==0){
          console.log("No Expense Found");
        }

      }
    });

    this.settlementServices.getSettlementByGroupId(id).subscribe({
      next:settle=>{
        console.log(settle);
        this.settlementDtoDetails=settle;
      }
    })
  }
  DeleteGroup(id:number){
    if(confirm('Really want to delete the group from splitwise?')){
      this.groupsServices.deleteGroup(id).subscribe(
        res=>{
          this.onSaveComplete();
        },
        err=>{
          console.log(err);
        }
      )
    }
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }
  showSettlement:boolean=false;
  ShowAndHide(){
    this.showSettlement=!this.showSettlement;
  }
}
