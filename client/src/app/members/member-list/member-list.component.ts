import { Component, inject, OnInit } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { Member } from '../../_models/member';
import { MemberCardComponent } from "../member-card/member-card.component";
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { AccountService } from '../../_services/account.service';
import { UserParams } from '../../_models/userParams';
import { FormsModule } from '@angular/forms';
import { ButtonsModule } from 'ngx-bootstrap/buttons';

@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [MemberCardComponent,PaginationModule,FormsModule,ButtonsModule],
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css'
})
export class MemberListComponent implements OnInit {
  memberService = inject(MembersService);
  private accountService= inject(AccountService);
  userParams= new UserParams(this.accountService.currentUser());
  genderList =[{value:'male',display:'Males'},{value:'female',display:'Females'}]
  //members: Member[] = [];


  ngOnInit(): void {
    if (!this.memberService.paginationResults())
      this.loadMembers();
  }

  loadMembers() {

    this.memberService.getMembers();

    // this.memberService.getMembers().subscribe({
    //   next: members => this.members = members
    // })
  }

  
  resetFilters(){
    //this.userParams= new UserParams (this.accountService.currentUser());
    this.memberService.resetParams();
    this.loadMembers();
  }

  pageChanged(event:any){

  //   if(this.userParams.pageNumber!== event.page){
  //     this.userParams.pageNumber = event.page;
  //     this.loadMembers();
  // }

    if(this.memberService.userParams().pageNumber!== event.page){
        this.memberService.userParams().pageNumber = event.page;
        this.loadMembers();
    }
  }
  

}
