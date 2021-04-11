import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PostDetailComponent } from './components/posts/post-detail/post-detail.component';
import { PostListComponent } from './components/posts/post-list/post-list.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'posts', component: PostListComponent, canActivate: [AuthGuard]},
      {path: 'posts/:id', component: PostDetailComponent},
      {path: '**', component: HomeComponent, pathMatch: "full"}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
