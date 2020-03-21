import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { QuestionaireComponent } from './questionaire.component';
import { ItemAgeComponent } from './item-age/item-age.component';
import { ItemResidentialSituationComponent } from './item-residential-situation/item-residential-situation.component';
import { ItemWorkingSituationComponent } from './item-working-situation/item-working-situation.component';
import { ItemSmokingSituationComponent } from './item-smoking-situation/item-smoking-situation.component';
import { ItemTraveledComponent } from './item-traveled/item-traveled.component';
import { ItemHeinsbergComponent } from './item-heinsberg/item-heinsberg.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    QuestionaireComponent,
    ItemAgeComponent,
    ItemResidentialSituationComponent,
    ItemWorkingSituationComponent,
    ItemSmokingSituationComponent,
    ItemTraveledComponent,
    ItemHeinsbergComponent
  ],
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: QuestionaireComponent
      },
    ]),
    CommonModule,
    FormsModule
  ]
})
export class QuestionaireModule { }
