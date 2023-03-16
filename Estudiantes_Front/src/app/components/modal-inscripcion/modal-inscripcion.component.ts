import { Component, Input } from '@angular/core';
import { EstudiantesService } from 'src/app/services/estudiantes.service';

@Component({
  selector: 'app-modal-inscripcion',
  templateUrl: './modal-inscripcion.component.html',
  styleUrls: ['./modal-inscripcion.component.css']
})
export class ModalInscripcionComponent {

  cursosDisponibles:any

  constructor(private estudianteService: EstudiantesService) {}

  @Input() public estudiante: any;

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    console.log(this.estudiante)
    this.consultarCursosEstudiante()
  }

  consultarCursosEstudiante() {
    this.estudianteService.seleccionarCursosEstudiantes(this.estudiante).subscribe(res => {
      this.cursosDisponibles = res
      console.log(res);
    })
  }

  eliminarCurso(id: number){
    try{
     this.estudianteService.eliminarInscripcion(id)
      alert('Inscrito correctamente')
    }catch {
      alert('Estudiante ya esta inscrito')
    }
  }
}
