import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Injectable } from '@angular/core';
import { ConfirmationDialogComponent } from './../../../Shared/Components/ConfirmationDialog/ConfirmationDialog.component';

@Injectable({
  providedIn: 'root'
})
export class ConfirmationDialogService {

constructor(private modalService: NgbModal) { }

public confirm(
  title: string,
  message: string,
  dialogSize: 'sm'|'lg' = 'sm'): Promise<boolean> {
  const modalRef = this.modalService.open(ConfirmationDialogComponent, { windowClass : "myCustomModalClass"});
  modalRef.componentInstance.title = title;
  modalRef.componentInstance.message = message;

  return modalRef.result;
}

}
