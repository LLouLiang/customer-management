import { mergeApplicationConfig, ApplicationConfig } from '@angular/core'; // Make sure this is the correct import path based on your Angular version
import { appConfig } from './app.config';

// Define any server-specific configuration if needed
const serverConfig: Partial<ApplicationConfig> = {
  // Example server configuration, add your own as needed
  providers: [
    // Add any specific providers for the server here
  ],
};

// Merge the appConfig with serverConfig
export const config: ApplicationConfig = mergeApplicationConfig(appConfig, serverConfig);