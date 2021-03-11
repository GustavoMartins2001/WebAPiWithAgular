import { Component, Inject, OnInit } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';
@Component({
  selector: 'app-uploadfile',
  templateUrl: './uploadfile.component.html',
  styleUrls: ['./uploadfile.component.scss']

})
export class UploadfileComponent implements OnInit {

  @Output() image = new EventEmitter<any>();
  public getImagem: any
  reader = new FileReader;
  imaggg:any;
  constructor(
  ) { }
  ngOnInit() {
  }
  uploadFile(event: any): void{
    this.getImagem = event.target.files[0];
    console.log(this.getImagem);
    this.reader.readAsDataURL(event.target.files[0])
    this.reader.onload = (event2)=>(
    this.imaggg = this.reader.result)
    console.log(this.reader);

  }

  emitFile(): void{
this.image.emit(this.getImagem);
  }

}
