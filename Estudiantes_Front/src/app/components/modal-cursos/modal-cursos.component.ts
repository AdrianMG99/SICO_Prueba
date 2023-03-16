import { Component, Input } from '@angular/core';
import { Iinscripciones } from 'src/app/models/inscripciones';
import { EstudiantesService } from 'src/app/services/estudiantes.service';

@Component({
  selector: 'app-modal-cursos',
  templateUrl: './modal-cursos.component.html',
  styleUrls: ['./modal-cursos.component.css']
})
export class ModalCursosComponent {
  cursosEstudiante: any;

  constructor(private estudianteService: EstudiantesService) {}

  @Input() public estudiante: any;

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    console.log(this.estudiante)
    this.consultarCursos()
  }

  consultarCursos() {
    this.estudianteService.seleccionarCursosDisponibles(this.estudiante).subscribe(res => {
      this.cursosEstudiante = res
      console.log(res)
    })
  }

  inscribiralCurso(id_curso: number){
    this.estudianteService.inscribirEstudiante(this.estudiante, id_curso).subscribe(res => {
      console.log(res)
    });
  }

}
