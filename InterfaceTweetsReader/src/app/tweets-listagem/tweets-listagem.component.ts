import { Component, OnInit } from '@angular/core';
import { TweetsService } from '../tweets.service';

@Component({
  selector: 'app-tweets-listagem',
  templateUrl: './tweets-listagem.component.html',
  styleUrls: ['./tweets-listagem.component.css']
})
export class TweetsListagemComponent implements OnInit {

  tweets: Array<any>;

  constructor(private tweetsService: TweetsService) { }

  ngOnInit() 
  {
    this.listar();
  }

  listar()
  {
    this.tweetsService.listar().subscribe(dados => this.tweets = dados);
  }


}
