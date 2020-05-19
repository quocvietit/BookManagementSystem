import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, ActivatedRoute } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { DataTableModule, SharedModule } from 'primeng/primeng';
import { GrowlModule } from 'primeng/primeng';
import { ButtonModule } from 'primeng/primeng';
import { ConfirmDialogModule } from 'primeng/primeng';
import { DialogModule } from 'primeng/primeng';
import { DropdownModule } from 'primeng/primeng';
import { ConfirmationService } from 'primeng/primeng';
import { MessagesModule } from 'primeng/primeng';
import { OverlayPanelModule } from 'primeng/primeng';

import { AppComponent } from './components/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { TopbarComponent } from './components/top-bar/top-bar.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { CategoryComponent } from './components/category/category.component';
import { CategoryEditComponent } from './components/category/category-edit/category-edit.component';
import { AuthorComponent } from './components/author/author.component';
import { AuthorEditComponent } from './components/author/author-edit/author-edit.component';
import { PublisherComponent } from './components/publisher/publisher.component';
import { PublisherEditComponent } from './components/publisher/publisher-edit/publisher-edit.component';
import { BookComponent } from './components/book/book.component';
import { BookEditComponent } from './components/book/book-edit/book-edit.component';

import { CategoryService } from './services/category.service';
import { AuthorService } from './services/author.service';
import { PublisherService } from './services/publisher.service';
import { BookService } from './services/book.service';
import { AuthGuardService } from './services/authGuard.service';
import { AuthenticationService} from './services/auth.service';
import { MainComponent } from './components/main/main.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        TopbarComponent,
        LoginComponent,
        NotFoundComponent,
        CategoryComponent,
        CategoryEditComponent,
        AuthorComponent,
        AuthorEditComponent,
        PublisherComponent,
        PublisherEditComponent,
        BookComponent,
        BookEditComponent,
        MainComponent
    ],
    providers: [
        CategoryService,
        AuthorService,
        BookService,
        PublisherService,
        ConfirmationService,
        AuthenticationService,
        AuthGuardService
    ],
    imports: [
        CommonModule,
        HttpModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        DataTableModule, SharedModule, GrowlModule, ConfirmDialogModule, DialogModule, ButtonModule, DropdownModule, MessagesModule, OverlayPanelModule,
        RouterModule.forRoot([
            {
                path: '', component: MainComponent, canActivate: [AuthGuardService], children: [
                    { path: '', redirectTo: 'home', pathMatch: 'full' },
                    { path: 'home', component: HomeComponent },
                    { path: 'category', component: CategoryComponent },
                    { path: 'category/add', component: CategoryEditComponent },
                    { path: 'category/edit/:id', component: CategoryEditComponent },
                    { path: 'author', component: AuthorComponent },
                    { path: 'author/add', component: AuthorEditComponent },
                    { path: 'author/edit/:id', component: AuthorEditComponent },
                    { path: 'publisher', component: PublisherComponent },
                    { path: 'publisher/add', component: PublisherEditComponent },
                    { path: 'publisher/edit/:id', component: PublisherEditComponent },
                    { path: 'book', component: BookComponent },
                    { path: 'book/add', component: BookEditComponent },
                    { path: 'book/edit/:id', component: BookEditComponent }
                ]
            },
            { path: 'login', component: LoginComponent },
            { path: 'not-found', component: NotFoundComponent },
            { path: '**', redirectTo: 'not-found' }
        ])
    ]
})
export class AppModuleShared {
}
