import { Directive, HostListener, HostBinding, ElementRef } from '@angular/core';

@Directive({
	selector: '[appDropdown]',
	exportAs: 'appDropdown'
})
export class DropdownDirective {
	@HostBinding('class.active') isOpen = false;

	// @HostListener('click')
	// toggleOpen() {
	// 	this.isOpen = !this.isOpen;
	// }

	@HostListener('document:click', [ '$event' ])
	toggleOpen(event: Event) {
		this.isOpen = this.elRef.nativeElement.contains(event.target) ? !this.isOpen : false;
	}

	constructor(private elRef: ElementRef) {}
}
