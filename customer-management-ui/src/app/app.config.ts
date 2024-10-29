import { Provider } from '@angular/core';

// Define the application configuration
export const appConfig: AppConfig = {
  // Example API URL; adjust according to your backend API
  apiUrl: 'http://localhost:3000/api',
  providers: [
  ]
  // Add any additional properties here as needed
};

// Optional: Create a function to get the API URL
export function getApiUrl(): string {
  return appConfig.apiUrl;
}

export interface AppConfig {
  apiUrl: string;
  providers?: Provider[];  // Make this optional
}