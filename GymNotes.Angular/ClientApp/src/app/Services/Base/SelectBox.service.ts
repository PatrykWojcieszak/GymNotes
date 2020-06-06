import { Injectable } from '@angular/core';
import * as $ from 'jquery';

@Injectable({
  providedIn: 'root'
})
export class SelectBoxService {

constructor() { }

  RunScript(){
    $('.dropdown').click(function () {
          $(this).attr('tabindex', 1).focus();
          $(this).toggleClass('active');
          $(this).find('.dropdown-menu').slideToggle(300);
      });
      $('.dropdown').focusout(function () {
          $(this).removeClass('active');
          $(this).find('.dropdown-menu').slideUp(300);
      });
      $('.dropdown .dropdown-menu li').click(function () {
          $(this).parents('.dropdown').find('span').text($(this).text());
          $(this).parents('.dropdown').find('input').val($(this).text());
      });
  }

}
