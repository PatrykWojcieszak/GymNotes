import { SpinnerComponent } from './../../../Shared/Components/Spinner/Spinner.component';
import { Injectable } from '@angular/core';
import { OverlayRef, Overlay } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';

@Injectable({
  providedIn: 'root'
})
export class SpinnerOverlayService {

  private overlayRef: OverlayRef = null;

  constructor(private overlay: Overlay) { }

  public show(message = '') {
    if (!this.overlayRef) {
      this.overlayRef = this.overlay.create();
    }

    const spinnerOverlayPortal = new ComponentPortal(SpinnerComponent);
    const component = this.overlayRef.attach(spinnerOverlayPortal);
  }

  public hide() {
    if (!!this.overlayRef) {
      this.overlayRef.detach();
    }
  }
}
