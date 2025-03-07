import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { NgIf, TitleCasePipe } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule, RouterLink,RouterLinkActive, TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);
  private router = inject(Router);
  private toastr = inject(ToastrService);
  private spinner = inject(NgxSpinnerService)
  model: any = {};


  login() {
    console.log(this.model);
    this.accountService.login(this.model).subscribe({

      next: response => {
        console.log(response);
        void this.router.navigateByUrl('/members')
        
      },
      error: error => this.toastr.error(error.error)
    });
  }

  logout() {
    this.accountService.logout();
    void this.router.navigateByUrl('/')
  }
  
  showSpinner()
  {
    this.spinner.show();
  }

}
