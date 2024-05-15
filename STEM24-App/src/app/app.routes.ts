import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { authGuard } from './guards/auth/auth.guard';
import { RegisterComponent } from './register/register.component';
import { PasswordResetComponent } from './password-reset/password-reset.component';
import { EventsComponent } from './events/events/events.component';
import { UpsertEventComponent } from './events/upsert-event/upsert-event.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'events',
        pathMatch: 'full',
    },

    // events routes
    {
        // canActivate: [authGuard],
        path: 'events',
        component: DashboardComponent,
        children: [
            {
                path: '',
                component: EventsComponent
            },
            {
                path: 'create',
                component: UpsertEventComponent
            },
            {
                path: 'update/:id',
                component: UpsertEventComponent
            }
        ],
    },

    // auth routes
    {
        path: 'login',
        component: LoginComponent,
    },
    {
        path: 'register',
        component: RegisterComponent,
    },
    {
        path: 'password-reset',
        component: PasswordResetComponent,
    },


    
    
];
