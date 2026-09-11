// import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
// import { provideRouter } from '@angular/router';
// import { routes } from './app.routes';
// import { provideClientHydration } from '@angular/platform-browser';

// export const appConfig: ApplicationConfig = {
//   providers: [
//     provideBrowserGlobalErrorListeners(),
//     provideRouter(routes), provideClientHydration()
//   ]
// };

//----------Version 1
// import { ApplicationConfig } from "@angular/core";
// import { provideRouter } from "@angular/router";
// import { provideHttpClient } from "@angular/common/http";
// import { routes } from './app.routes';

// export const appConfig: ApplicationConfig = {
//   providers:[
//     provideRouter(routes),
//     provideHttpClient()       //IMPORTANTE: HABILITAR HttpClient
//   ]
// }; 

// app.config.ts o main.ts
import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
//import { ApplicationConfig } from '@angular/core';
import { provideClientHydration } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
     provideBrowserGlobalErrorListeners(),
    provideHttpClient(withInterceptorsFromDi()),   //  habilita httpclient
    provideRouter(routes),
    provideClientHydration()
  ]
};

