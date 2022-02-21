import { MatFormFieldModule } from '@angular/material/form-field';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalComponent } from './modal/modal.component';
import {MatDialogModule} from '@angular/material/dialog';
import { MatInputModule, MatButtonModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [ModalComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,

    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  exports: [
  ModalComponent
  ],
  entryComponents: [
    ModalComponent
  ]
})
export class SharedModule { }
