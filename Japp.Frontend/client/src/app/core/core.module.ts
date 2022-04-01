import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxsStoreModule } from './store/store.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgxsStoreModule,
  ],
  exports: [
    NgxsStoreModule,
  ]
})
export class CoreModule { }
