import { Component, OnInit } from '@angular/core';
import { MedicalInstituteSignUp } from '../../models/medical-institute-sign-up.model';
import { Router } from '@angular/router';
import { MedicalInstituteSignUpService } from '../../services/medical-institute-sign-up.service';
import { AlertService } from 'src/app/services/alert.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-medical-institute-sign-up',
  templateUrl: './medical-institute-sign-up.component.html',
  styleUrls: ['./medical-institute-sign-up.component.css']
})
export class MedicalInstituteSignUpComponent implements OnInit {
  model: MedicalInstituteSignUp = {
    address: {}
  };
  isRequesting: boolean;

  constructor(
    private router: Router,
    private authService: AuthService,
    private signUpService: MedicalInstituteSignUpService,
    private alertService: AlertService) {
  }

  ngOnInit() {
    this.authService.logout();
  }

  signUp() {
    this.isRequesting = true;
    this.signUpService.createUser(this.model)
      .subscribe(
        data => {
          this.isRequesting = false;
          this.router.navigate(['/email-confirmation-sent'], { state: { email: this.model.email } });
          this.alertService.success('Ihre Anmeldung war erfolgreich. Bitte bestätigen Sie noch Ihre Email-Adresse.');
        },
        error => {
          this.isRequesting = false;
          this.alertService.error(error);
        }
      );
  }

}
