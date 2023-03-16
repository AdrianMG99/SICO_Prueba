import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Iestudiante } from '../models/estudiante';
import { Iinscripciones } from '../models/inscripciones';

@Injectable({
  providedIn: 'root'
})
export class EstudiantesService {

  constructor(private http: HttpClient) { }

  url: string = '/api/Estudiantes';

  getEstudiantes() {
    console.log(this.url)
    return this.http.get<Iestudiante>(this.url)
  }

  inscribirEstudiante(idEstudiante: number, idCurso: number){
    return this.http.get(`${this.url}/${idEstudiante}/${idCurso}`)
  }

  seleccionarCursosEstudiantes(idEstudiantes: number) {
    console.log(`${this.url}/${idEstudiantes}`)
    return this.http.get<Iinscripciones>(`${this.url}/${idEstudiantes}`);
  }

  seleccionarCursosDisponibles(id_estudiante: number){
    const body = {id_estudiante: id_estudiante, cursosDisponibles: 'cursosDisponibles'}
    return this.http.post<Iinscripciones>(`${this.url}/${id_estudiante}/cursosDisponibles`,body);
  }

  eliminarInscripcion(idInscripcion: number){
    return this.http.delete(`${this.url}/${idInscripcion}`);
  }
}
