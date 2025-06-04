import { RouterOutlet } from '@angular/router';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NytService } from './nyt.service';

interface HierarchicalData {
  id: number;
  name: string;
  children?: HierarchicalData[];
}

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CommonModule, ReactiveFormsModule, HttpClientModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class AppComponent {
  
  protected title = 'testmanali';
   apiKey = '';
  articles: any[] = [];
  error = '';
  myForm!: FormGroup;

  constructor(private nytService: NytService, private fb: FormBuilder) {}

  ngOnInit() {
  this.myForm = this.fb.group({
    apiKey: ['', [Validators.required, Validators.minLength(2)]]
  });
}

  submit() {
    if (!this.myForm.controls['apiKey'].value) {
      this.error = 'API Key is required';
      return;
    }
    this.nytService.loadData(this.myForm.controls['apiKey'].value).subscribe({
      next: data => this.articles = data as any[],
      error: err => this.error = err.message
    });
  }
}
