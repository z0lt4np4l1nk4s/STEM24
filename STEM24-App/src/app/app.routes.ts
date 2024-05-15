import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { authGuard } from './guards/auth/auth.guard';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
    },

    // auth routes
    {
        path: 'login',
        component: LoginComponent,
    },
    {
        path: 'register',
        component: LoginComponent,
    },
    {
        path: 'password-reset',
        component: LoginComponent,
    },


    {
        canActivate: [authGuard],
        path: 'dashboard',
        component: DashboardComponent,
    },
    
];
