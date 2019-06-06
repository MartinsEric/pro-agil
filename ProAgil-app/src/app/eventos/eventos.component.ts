import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { FormGroup, FormBuilder ,Validators } from '@angular/forms';
import { defineLocale, BsLocaleService, ptBrLocale } from 'ngx-bootstrap';
import { temporaryAllocator } from '@angular/compiler/src/render3/view/util';

defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  eventosFiltrados: Evento[];
  eventos: Evento[];
  evento: Evento;
  imagemLargura = 50;
  imagemMargem = 2;
  mostarImagem = false;
  registerForm: FormGroup;
  modoSalvar = 'post';
  _filtroLista = '';

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService
    ) {
      this.localeService.use('pt-br');
    }

  get filtroLista(): string{
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }


  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  ngOnInit() {
    this.validation();
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  alternarImagem(){
    this.mostarImagem = !this.mostarImagem;
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if(this.modoSalvar === 'post'){
        this.evento = Object.assign({}, this.registerForm.value);
        this.eventoService.postEvento(this.evento).subscribe(
          (novoEvento: Evento) => {
            console.log(novoEvento);
            template.hide();
            this.getEventos();
        }, error => {
          console.log(error);
        });
      } else {
        this.evento = Object.assign({id: this.evento.id}, this.registerForm.value);
        this.eventoService.putEvento(this.evento).subscribe(
          () => {
            template.hide();
            this.getEventos();
        }, error => {
          console.log(error);
        });
      }
    }
  }

  editarEvento(evento: Evento, template: any){
    this.modoSalvar = 'put';
    this.openModal(template);
    this.evento = evento;
    this.registerForm.patchValue(evento);

  }

  novoEvento(template: any){
    this.modoSalvar = 'post';
    this.openModal(template);
  }

  validation() {
    this.registerForm = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', [Validators.required]],
      date: ['', [Validators.required]],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      imageUrl: ['', [Validators.required]],
      telefone: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  getEventos() {
    this.eventoService.getAllEvento().subscribe(
      (_eventos: Evento[]) => {
      this.eventos = _eventos;
      console.log(this.eventos);
      }, error => {
        console.log(error);
      });
  }

}
