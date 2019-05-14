import { Component, OnInit, Input, OnChanges, SimpleChanges, EventEmitter, Output } from '@angular/core';
import { MovieService } from '@collectors/movie/movie.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit, OnChanges {
  
  ngOnChanges(changes: SimpleChanges): void {
    if(changes.shouldClean.currentValue){
      this.searchRes = null;
      this.searchStr = '';
      this.cleaned.emit();
    }
  }

  @Output() cleaned: EventEmitter<any> = new EventEmitter();;
  @Input() shouldClean !: any;
  current_page_search: number;
  last_page_search: number;
  searchRes: Array<Object>;
  searchStr: string;

  constructor(private _moviesService: MovieService) { }

  ngOnInit() {
  }

  searchMovies() {
    this._moviesService.searchMovies(this.searchStr, 1).subscribe(res => {
      this.searchRes = res.Results;
      this.current_page_search = 1;
      this.last_page_search = res.Total_Pages;
    })
  }

  
  movePageFirstSearch() {
    this._moviesService.searchMovies(this.searchStr, 1).subscribe(res => {
      this.searchRes = res.Results;
    });
  }

  movePageLastSearch() {
    this._moviesService.searchMovies(this.searchStr, this.last_page_search).subscribe(res => {
      this.searchRes = res.Results;
      this.current_page_search = this.last_page_search;
    });
  }

  movePageForwardSearch() {
    if (this.current_page_search < this.last_page_search) {
      this.current_page_search += 1;
      this._moviesService.searchMovies(this.searchStr, this.current_page_search).subscribe(res => {
        this.searchRes = res.Results;
      });
    }
  }

  movePageBackwardSearch() {
    if (this.current_page_search > 1) {
      this.current_page_search -= 1;
      this._moviesService.searchMovies(this.searchStr, this.current_page_search).subscribe(res => {
        this.searchRes = res.Results;
      });
    }
  }

}
