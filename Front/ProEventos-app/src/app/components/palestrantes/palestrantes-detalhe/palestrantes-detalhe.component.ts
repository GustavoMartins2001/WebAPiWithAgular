import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PalestranteService } from 'src/app/services/palestrante.service';

@Component({
  selector: 'app-palestrantes-detalhe',
  templateUrl: './palestrantes-detalhe.component.html',
  styleUrls: ['./palestrantes-detalhe.component.scss']
})
export class PalestrantesDetalheComponent implements OnInit {
  // redeSocial!: FormGroup;
  form!: FormGroup;
  redesSociais = new FormArray([]);
  constructor(
    public http: HttpClient,
    public palestranteService: PalestranteService,
    public fb: FormBuilder,
    public router: Router
  ) { }

  ngOnInit() {

   this.validation();
  }

  public validation(): void{
    this.form = this.fb.group({
     nome: [''],
     miniCurriculo: [''],
     email: [''],
     telefone: [''],
     redesSociais: this.fb.array([

     ])



    });
  }

  public addRedeFormGroup(): FormGroup {
    return this.fb.group({
      nome: [''],
      url: ['']
    });
  }
  public addRedeInput():any{

  }
  public addRede(): void{
    this.redesSociais = this.form.get('redesSociais') as FormArray;
  this.redesSociais.push(this.addRedeFormGroup());
  }


   public submitForm(): void{
     this.palestranteService.postPalestrante(this.form.value).subscribe(
      (data) => {
         console.log('Form submitted successfully');
         this.redirectLista();
      },
      (error: HttpErrorResponse) => {
          console.log(error);
      }
    );
  }

  public redirectLista(): void{
    this.router.navigate(['palestrantes/lista/']);
    }


}
