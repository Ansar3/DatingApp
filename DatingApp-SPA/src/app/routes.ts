import { HomeComponent } from './home/home.component';
import { Routes, CanActivate } from '@angular/router';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListComponent } from './list/list.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes-guard';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent },
    {path: '', runGuardsAndResolvers: 'always' , 
    children:[
    {path: 'members', component: MemberListComponent },
    { path: 'members/edit',component:MemberEditComponent ,resolve:{user:MemberEditResolver},canDeactivate:[PreventUnsavedChanges] },
    {path: 'members/:id', component: MemberDetailComponent,resolve:{user:MemberDetailResolver} },
    { path: 'members/edit',component:MemberEditComponent ,resolve:{user:MemberEditResolver} },
    {path: 'messages', component: MessagesComponent },
    {path: 'lists', component: ListComponent },
    {path: 'home', component: HomeComponent }]},
    {path: '**', redirectTo : 'home', pathMatch: 'full' }
];
