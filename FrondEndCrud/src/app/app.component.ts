import {AfterViewInit, Component, ViewChild, OnInit} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';

import { Persona } from './Interface/persona';
import { PersonaService } from './Services/persona.service';
import { Usuario } from './Interface/usuario';
import { UsuarioService } from './Services/usuario.service';

import {MatButtonModule} from '@angular/material/button';

import { DialogAddEditComponent }from './Dialogs/dialog-add-edit/dialog-add-edit.component'
import { DialogAddEditUsersComponent }from './Dialogs/dialog-add-edit-users/dialog-add-edit-users.component'

import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogTitle,
} from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['Nombres', 'Apellidos', 'No_Identificacion', 'Email', 'Tp_Identificacion', 'Fecha_Creacion', 'IdentificacionCompleta','NombreCompleto','Acciones'];
  displayedColumnsUser: string[] = ['Usuario', 'Pass','Fecha_Creacion','Acciones'];
  dataSource = new MatTableDataSource<Persona>();
  dataSourceUser = new MatTableDataSource<Usuario>();

  constructor(private _personaServicio : PersonaService, private _usuarioServicio : UsuarioService, public dialog: MatDialog)
  {
    if(_personaServicio != null)
    {
      
    }
    if(_usuarioServicio !=  null)
    {
      
    }
  }

  ngOnInit(): void 
  {
    this.mostrarPersonas();
    this.mostrarUsuarios();
  }
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  applyFilterUser(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  mostrarPersonas()
  {
    this._personaServicio.getList().subscribe({
      next:(dataResponse)=>{
        console.log(dataResponse)
        this.dataSource.data = dataResponse;
      },error:(e)=>{}})
  }

  mostrarUsuarios()
  {
    this._usuarioServicio.getList().subscribe({
      next:(dataResponse)=>{
        console.log(dataResponse)
        this.dataSourceUser.data = dataResponse;
      },error:(e)=>{}})
  }

  openDialog() {
    this.dialog.open(DialogAddEditComponent,{
      disableClose:true,
      width:"350px"
    }).afterClosed().subscribe(resultado => {
      if(resultado === "creado")
      {
        this.mostrarPersonas();
      }
    });
  }

  openDialogUsers() {
    this.dialog.open(DialogAddEditUsersComponent);
  }
}