import { SweetAlertService } from './../../shared/services/SweetAlert.service';
import { EventoService } from './../../evento/evento.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ComunicacaoPerdaService } from '../comunicacao-perda.service';
import { ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';
import { CpfValidatorService } from 'src/app/shared/validators/CpfValidator.service';

@Component({
  selector: 'app-comunicacao-perda-edit',
  templateUrl: './comunicacao-perda-edit.component.html',
  styleUrls: ['./comunicacao-perda-edit.component.css'],
})
export class ComunicacaoPerdaEditComponent implements OnInit {
  get f() {
    return this.form.controls;
  }

  public customPatterns = {
    '0': { pattern: new RegExp('^(-?d+(.d+)?),s*(-?d+(.d+)?)$') },
  };
  comunicadoSemelhanteExistente = false;
  submitted = false;
  form: FormGroup;
  eventos: any = [];
  id: number = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private alertService: SweetAlertService,
    private fb: FormBuilder,
    private eventoService: EventoService,
    private cpService: ComunicacaoPerdaService,
    private cpfValidatorService: CpfValidatorService
  ) {
    this.form = this.fb.group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      cpf: ['', [Validators.required]],
      dataColheita: ['', [Validators.required]],
      tipoLavoura: ['', [Validators.required]],
      eventoOcorrido: ['', [Validators.required]],
      localizacaoLongitude: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$/
          ),
        ],
      ],
      localizacaoLatitude: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$/
          ),
        ],
      ],
    });
  }

  async ngOnInit() {
    try {
      this.id = Number(this.route.snapshot.paramMap.get('id'));
      this.eventos = await this.eventoService.getAll();

      var cpData: any = await this.cpService.getById(this.id);

      this.form.setValue({
        nome: cpData.nome,
        email: cpData.email,
        cpf: cpData.cpf,
        dataColheita: formatDate(cpData.dataColheita, 'yyyy-MM-dd', 'pt-BR'),
        tipoLavoura: cpData.tipoLavoura,
        eventoOcorrido: cpData.eventoOcorrido,
        localizacaoLongitude: cpData.localizacaoLongitude,
        localizacaoLatitude: cpData.localizacaoLatitude,
      });
    } catch {
      await this.alertService.alertError(
        'Erro ao obter a comunicação de perda'
      );
      this.router.navigate(['comunicacao-perda/list']);
    }
  }

  cancelar() {
    this.router.navigate(['comunicacao-perda/list']);
  }

  async submit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    let cpfValido = await this.cpfValidatorService.cpfValido(this.f.cpf.value);

    if (!cpfValido) {
      await this.alertService.alertError(
        'O CPF informado é inválido'
      );

      return;
    }

    let checkEventoRequest = {
      id: this.id,
      evento: this.f.eventoOcorrido.value,
      localizacaoLatitude: this.f.localizacaoLatitude.value,
      localizacaoLongitude: this.f.localizacaoLongitude.value,
      data: this.f.dataColheita.value,
    };

    let checkEventoResponse: any =
      await this.cpService.postComunicacaoPerdaExistente(checkEventoRequest);

    if (checkEventoResponse.length > 0) {
      let result = await this.alertService.alertConfirm(
        'Existe uma comunicação de perda com a mesma data, em um raio de 10Km. Deseja continuar?'
      );

      if (result.isConfirmed) {
        await this.salvar();
      }
    } else {
      await this.salvar();
    }
  }

  async salvar() {
    await this.cpService.put(this.id, this.form.value);

    await this.alertService.alertSuccess(
      'Comunicação de perda atualizada com sucesso'
    );
    this.router.navigate(['comunicacao-perda/list']);
  }
}
