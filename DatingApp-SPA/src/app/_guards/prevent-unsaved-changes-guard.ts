import { Injectable } from "@angular/core";
import { CanDeactivate } from '@angular/router';
import { MemberListComponent } from '../members/member-list/member-list.component';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<MemberEditComponent> {
    canDeactivate(component: MemberEditComponent)
    {
        if(component.editForm.dirty){
            return confirm('Are you sure you want to continnue? Any unsaved changes will be lost');
        }
        return true;
    }
}