import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { API_BASE_URL } from './api.config';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

interface Square {
  row: number;
  column: number;
  isOpen: boolean;
  prizeAmount: number;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  allSquares: Square[] = [];

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.initializeGrid();
    this.loadOpenSquares();
  }

  initializeGrid(): void {
    for (let row = 1; row <= 100; row++) {
      for (let column = 1; column <= 100; column++) {
        this.allSquares.push({
          row: row,
          column: column,
          isOpen: false,
          prizeAmount: 0
        });
      }
    }
  }

  loadOpenSquares(): void {
    const url = `${API_BASE_URL}/SurpriseCalendar/open-squares`;
    this.http.get<Square[]>(url)
      .subscribe((openSquares: Square[]) => {
        openSquares.forEach(openSquare => {
          const index = this.allSquares.findIndex(s => s.row === openSquare.row && s.column === openSquare.column);
          if (index !== -1) {
            this.allSquares[index] = openSquare;
          }
        });
      });
  }

  scratchSquare(square: Square): void {
    const url = `${API_BASE_URL}/SurpriseCalendar/scratch`;
    if (!square.isOpen) {
      this.http.post(url, {
        row: square.row,
        column: square.column,
        userId: this.getUserId()
      }).subscribe((result: any) => {
        if (result) {
          square.isOpen = true;
          square.prizeAmount = result.prizeAmount;
        } else {
          alert('You have already opened a square');
        }
      },
    (error : any) => {
      if (error.status === 500) {
        alert('An unexpected error occurred. Please try again later.');
      }
    });
    }
  }

  getUserId(): number {
    let userId = sessionStorage.getItem('UserId');
    if (!userId) {
      userId = Math.floor(Math.random() * 1000000).toString();
      sessionStorage.setItem('UserId', userId);
    }
    return parseInt(userId);
  }

}
