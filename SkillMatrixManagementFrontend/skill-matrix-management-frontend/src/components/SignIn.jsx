import * as React from 'react';
import Checkbox from '@mui/material/Checkbox';
import { AppProvider } from '@toolpad/core/AppProvider';
import { SignInPage } from '@toolpad/core/SignInPage';
import { useTheme } from '@mui/material/styles';

const providers = [{ id: 'credentials', name: 'Email and Password' }];

export default function SlotPropsSignIn() {

const handleLogin = async (formData) => {
    const response = await fetch('https://localhost:44302/api/account/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        userNameOrEmailAddress: formData.get('email'),
        password: formData.get('password'),
        rememberMe: true,
      }),
    });

    if (response.ok) {
      const data = await response.json();
      console.log('Login successful:', data);
    } else {
      console.error('Login failed');
    }
  };

  const theme = useTheme();
  return (
    <AppProvider theme={theme}>
      <SignInPage 
        localeText={{ signInTitle: "SignIn to Skill Matrix" }}
        signIn={ async (provider, formData) =>
          await handleLogin(formData)
        }
        slotProps={{
          emailField: { variant: 'standard', autoFocus: false },
          passwordField: { variant: 'standard' },
          submitButton: { variant: 'outlined' },
          rememberMe: {
            control: (
              <Checkbox
                name="tandc"
                value="true"
                color="primary"
                sx={{ padding: 0.5, '& .MuiSvgIcon-root': { fontSize: 20 } }}
              />
            ),
            color: 'textSecondary',
            label: 'I agree with the T&C',
          },
        }}
        providers={providers}
      />
    </AppProvider>
  );
}
