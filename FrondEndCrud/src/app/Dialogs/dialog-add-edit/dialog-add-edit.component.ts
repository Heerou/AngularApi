import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

import { MatSnackBar } from '@angular/material/snack-bar';

import { MAT_DATE_FORMATS } from '@angular/material/core';
import * as moment from 'moment';

import { Persona } from 'src/app/Interface/persona';
import { PersonaService } from 'src/app/Services/persona.service';

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
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.css'],
  providers:[
    {provide:MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS}
  ]
})
export class DialogAddEditComponent implements OnInit {

  formPersona:FormGroup;
  tituloAccion:string = "Nueva";
  botonAccion:string = "Guardar";

  constructor(
    private dialogoReferencia:MatDialogRef<DialogAddEditComponent>,
    private fb: FormBuilder,
    private _snackBar:MatSnackBar,
    private _personaServicio:PersonaService
    ) 
    {
      this.formPersona=this.fb.group
      ({
        nombres:['',Validators.required],
        apellidos:['',Validators.required],
        noIdentificacion:['',Validators.required],
        email:['',Validators.required],
        tpIDentificacion:['',Validators.required]
      })      
    }

  monstrarAlerta(msg: string, accion: string) 
  {
    this._snackBar.open(msg, accion,{
      horizontalPosition:"end",
      verticalPosition:"top",
      duration:3000
    });
  }

  addEditPersona()
  {    
    console.log(this.formPersona.value);

    const modelo:Persona=
    {
      id:2,
      nombres:this.formPersona.value.nombres,
      apellidos:this.formPersona.value.apellidos,
      noidentificacion:this.formPersona.value.noidentificacion,
      email:this.formPersona.value.email,
      tpidentificacion:this.formPersona.value.tpidentificacion,
      fechacreacion:moment(Date()).format("DD/MM/YYYY"),
      identificacionCompleta:this.formPersona.value.noidentificacion+this.formPersona.value.tpidentificacion,
      nombreCompleto:this.formPersona.value.nombre+this.formPersona.value.apellidos
    }

    this._personaServicio.add(modelo).subscribe(
      {
        next:(data)=>{
          this.monstrarAlerta("Empleado Creado","Listo");
          this.dialogoReferencia.close("creado");
        },error:(e)=>{
          console.log(e);
          this.monstrarAlerta("No se pudo crear","Error");
        }
      }
    );
  }

  ngOnInit(): void {
  }

}
