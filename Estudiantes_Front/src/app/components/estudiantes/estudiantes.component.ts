import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Iestudiante } from 'src/app/models/estudiante';
import { Iinscripciones } from 'src/app/models/inscripciones';
import { EstudiantesService } from 'src/app/services/estudiantes.service';
import { ModalCursosComponent } from '../modal-cursos/modal-cursos.component';
import { ModalInscripcionComponent } from '../modal-inscripcion/modal-inscripcion.component'

@Component({
  selector: 'app-estudiantes',
  templateUrl: './estudiantes.component.html',
  styleUrls: ['./estudiantes.component.css'],
  providers: [EstudiantesService]
})
export class EstudiantesComponent {
  estudiantes: any;
  cursosEstudiante: any;
  cursosDisponibles:any;
  openCursos = false;
  openCursosDisponibles = false;

  actualEstudiante: number = 0;

  datatable:any = []


  constructor(
    private modalService: NgbModal,
    private estudiantesService: EstudiantesService
    ){}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.onDataTable();
  }

  onDataTable(){
    this.estudiantesService.getEstudiantes().subscribe(res => {
      this.estudiantes = res;
    });

  }
  public estudianteId = 0;

  openModalCursosDisponibles(id_estudiante: number) {
    this.estudianteId =  id_estudiante
    const modalRef = this.modalService.open(ModalInscripcionComponent, {size: 'xl'});
    modalRef.componentInstance.estudiante = this.estudianteId;
  }

  openModalCursosEstudiante(id_estudiante: number) {
    this.estudianteId = id_estudiante;
    const modalRef = this.modalService.open(ModalCursosComponent,{size: 'xl'});
    modalRef.componentInstance.estudiante = this.estudianteId
  }

}
