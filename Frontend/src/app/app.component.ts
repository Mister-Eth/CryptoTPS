import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MediaMatcher} from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { MatIcon } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @ViewChild('sidenav') sidenav?: MatSidenav;
  @ViewChild('dark-theme-icon') darkThemeIcon?: MatIcon;

  public title = 'L2 stats';

  private _mobileQueryListener: () => void;
  public mobileQuery: MediaQueryList;

  public darkTheme = true;

  constructor(changeDetectorRef: ChangeDetectorRef, 
              media: MediaMatcher,
              public dialog: MatDialog) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);    
  }

  public sidenavItemClicked() {
    if (this.mobileQuery.matches)
      this.sidenav?.close(); 
  }

  onThemeChange(event: any) {
    this.darkTheme=!this.darkTheme;
    if (!this.darkTheme) {
      document.body.classList.remove("dark-theme");
    }
    else {
      document.body.classList.add("dark-theme");
    }
  }
}