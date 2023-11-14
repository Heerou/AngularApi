import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

import { MatSnackBar } from '@angular/material/snack-bar';

import { MAT_DATE_FORMATS } from '@angular/material/core';
import * as moment from 'moment';

import { Usuario } from 'src/app/Interface/usuario';
import { UsuarioService } from 'src/app/Services/usuario.service';

export const MY_DATE_FORMATS=
{
  parse:{
    dateInput:'DD/MM/YYYY',
  },
  display:{
    dateInput:'DD/MM/YYYY',
    monthYearLabel:'MMMMM YYYY',
    dateA11yLabel:'LL',
    montYeardA11yLabel:'MMMMM YYYY'
  }
}

@Component({
  selector: 'app-dialog-add-edit-users',
  templateUrl: './dialog-add-edit-users.component.html',
  styleUrls: ['./dialog-add-edit-users.component.css'],
  providers:[
    {provide:MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS}
  ]
})
export class DialogAddEditUsersComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
