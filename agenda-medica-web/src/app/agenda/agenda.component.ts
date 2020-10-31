import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Agenda } from '../Models/agenda';
import { AgendaService } from './agenda.service';

@Component({
  selector: 'app-agenda',
  templateUrl: './agenda.component.html',
  styleUrls: ['./agenda.component.scss']
})
export class AgendaComponent implements OnInit {

  public agendaForm: FormGroup;
  public titulo = 'Agendas';
  public agendaSelecionada: Agenda;
  public opcaoEditar = false;
  public opcaoDetalhar = false;
  public opcaoCadastrar = false;
  public msgErro = "";

  public agendas:Agenda[];

  constructor(private fb: FormBuilder, private agendaService:AgendaService) {
    this.criarForm();
  }

    ngOnInit() {
      this.carregarAgendas();
    }

    carregarAgendas(){
      this.agendaService.listarTodos().subscribe(
        (agendas:Agenda[]) => {
          this.agendas = agendas;
          this.agendas.forEach(agenda => {
            agenda.dataNascimentoPaciente = this.formatarData(agenda.dataNascimentoPaciente);
            agenda.dataInicialConsulta = this.formatarDataHora(agenda.dataInicialConsulta);
            agenda.dataFimConsulta = this.formatarDataHora(agenda.dataFimConsulta);
          });
         },
        (erro:any) => { console.error(erro) }
      );
    }

    formatarData(data:string){
      if(data){
        return data.split('T')[0];
      }
    }

    formatarDataHora(dataHora:string){
      if(dataHora){
        return dataHora.slice(0, -3);
      }
    }

    criarForm(){
      this.agendaForm = this.fb.group({
        id:0,
        nomePaciente: ['', Validators.required],
        dataNascimentoPaciente: ['', Validators.required],
        dataInicialConsulta: ['', Validators.required],
        dataFimConsulta:['', Validators.required],
        observacoes:['']
      });
    }

  detalhar(agenda:Agenda){
    this.agendaSelecionada = agenda;
    this.opcaoDetalhar = true;
    this.agendaForm.patchValue(agenda);
  }

  editar(agenda:Agenda){
    this.agendaSelecionada = agenda;
    this.opcaoEditar = true;
    this.msgErro = '';
    this.agendaForm.patchValue(agenda);
  }

  editarSubmit(){
    this.salvarEditar(this.agendaForm.value);
  }

  salvarEditar(agenda:Agenda){
    this.agendaService.put(agenda).subscribe(
      (agenda : Agenda) => {
        this.msgErro = "";
        this.carregarAgendas();
        this.opcaoEditar = false;
        this.agendaSelecionada = null;
        console.log(agenda);
      },
      (error : any) => {
        this.msgErro = error.error;
        console.log(error);
      }
    );
  }

  cadastrar(){
    this.criarForm();
    var agenda = new Agenda();
    this.agendaSelecionada = agenda;
    this.msgErro = '';
    this.opcaoCadastrar = true;
    this.agendaForm.patchValue(agenda);
  }

  cadastrarSubmit(){
    this.salvarCadastrar(this.agendaForm.value);
  }

  salvarCadastrar(agenda:Agenda){
    console.log(agenda);
    this.agendaService.post(agenda).subscribe(
      (agenda : Agenda) => {
        this.msgErro = "";
        this.carregarAgendas();
        this.opcaoCadastrar = false;
        this.agendaSelecionada = null;
        console.log(agenda);
      },
      (error : any) => {
        this.msgErro = error.error;
        console.log(error);
      }
    );
  }

  deletar(agenda:Agenda){
    this.agendaService.delete(agenda).subscribe(
      (agenda : Agenda) => {
        this.msgErro = "";
        this.carregarAgendas();
        this.agendaSelecionada = null;
        console.log(agenda);
      },
      (error : any) => {
        this.msgErro = error.error;
        console.log(error);
      }
    );
  }

  voltar(){
    this.agendaSelecionada = null;
    this.opcaoDetalhar = false;
    this.opcaoEditar = false;
    this.opcaoCadastrar = false;
  }

}
