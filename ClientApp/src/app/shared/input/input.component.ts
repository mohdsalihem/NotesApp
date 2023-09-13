import { Component, Input, OnInit } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { NgIf, NgClass } from '@angular/common';

@Component({
    selector: 'app-input',
    templateUrl: './input.component.html',
    styles: [],
    standalone: true,
    imports: [
        NgIf,
        ReactiveFormsModule,
        NgClass,
    ],
})
export class InputComponent implements OnInit {
  @Input() control: FormControl = new FormControl();
  @Input() type = 'text';
  @Input() placeholder = '';
  @Input() fieldName = 'Field';
  @Input() maskFormat = '';

  ngOnInit(): void {}
}
