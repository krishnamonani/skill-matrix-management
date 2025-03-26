import React, { useState } from 'react';
import { Eye, EyeOff, AlertCircle, User, Mail, Lock } from 'lucide-react';

const SignInPage = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [username, setUsername] = useState('');
    const [rememberMe, setRememberMe] = useState(false);
    const [showPassword, setShowPassword] = useState(false);
    const [errors, setErrors] = useState({});
    const [isRegistering, setIsRegistering] = useState(false);

    const validateEmail = (email) => {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    };

    const validatePassword = (password) => {
        const hasUppercase = /[A-Z]/.test(password);
        const hasLowercase = /[a-z]/.test(password);
        const hasNumber = /[0-9]/.test(password);
        const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(password);

        return password.length >= 6 &&
            hasUppercase &&
            hasLowercase &&
            hasNumber &&
            hasSpecialChar;
    };

    const validateUsername = (username) => {
        return username.length >= 3;
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const newErrors = {};

        if (isRegistering) {
            if (!username) {
                newErrors.username = 'Username is required';
            } else if (!validateUsername(username)) {
                newErrors.username = 'Username must be at least 3 characters long';
            }
        }

        if (!email) {
            newErrors.email = 'Email is required';
        } else if (!validateEmail(email)) {
            newErrors.email = 'Invalid email format';
        }

        if (!password) {
            newErrors.password = 'Password is required';
        } else if (!validatePassword(password)) {
            newErrors.password = 'Password must be at least 6 characters long and contain uppercase, lowercase, number, and special character';
        }

        setErrors(newErrors);

        if (Object.keys(newErrors).length === 0) {
            console.log('Form submitted', {
                username: isRegistering ? username : undefined,
                email,
                password,
                rememberMe
            });
        }
    };

    const toggleRegistration = () => {
        setIsRegistering(!isRegistering);
        setEmail('');
        setPassword('');
        setUsername('');
        setErrors({});
    };

    return (
        <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-blue-50 to-blue-100 p-4 overflow-hidden">
            <div className="relative w-full max-w-4xl h-[600px] flex shadow-2xl rounded-2xl overflow-hidden">
                {/* Sliding Container */}
                <div className={`
          absolute inset-0 z-10 flex transition-all duration-700 ease-in-out
          ${isRegistering
                        ? 'translate-x-full'
                        : 'translate-x-0'
                    }
        `}>
                    {/* Sign In Form Panel (Sliding) */}
                    <div className={`
            w-1/2 bg-white p-12 flex flex-col justify-center transition-all duration-700 ease-in-out
            ${isRegistering
                            ? '-translate-x-full'
                            : 'translate-x-0'
                        }
          `}>
                        <h2 className="text-2xl font-bold mb-6 text-center text-blue-800">
                            Sign In
                        </h2>

                        <form onSubmit={handleSubmit} className="space-y-4">
                            {/* Email Input */}
                            <div>
                                <label htmlFor="email" className="block text-sm font-medium text-gray-700 mb-2">
                                    Email
                                </label>
                                <div className="relative">
                                    <Mail className="absolute left-3 top-1/2 transform -translate-y-1/2 text-blue-500" size={20} />
                                    <input
                                        type="email"
                                        id="email"
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                        className={`w-full px-3 py-2 pl-10 border rounded-md focus:outline-none focus:ring-2 
                      ${errors.email ? 'border-red-500 focus:ring-red-500' : 'border-gray-300 focus:ring-blue-500'}`}
                                        placeholder="Enter your email"
                                    />
                                </div>
                                {errors.email && (
                                    <div className="text-red-500 text-sm mt-1 flex items-center">
                                        <AlertCircle className="mr-2 h-4 w-4" />
                                        {errors.email}
                                    </div>
                                )}
                            </div>

                            {/* Password Input */}
                            <div>
                                <label htmlFor="password" className="block text-sm font-medium text-gray-700 mb-2">
                                    Password
                                </label>
                                <div className="relative">
                                    <Lock className="absolute left-3 top-1/2 transform -translate-y-1/2 text-blue-500" size={20} />
                                    <input
                                        type={showPassword ? "text" : "password"}
                                        id="password"
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        className={`w-full px-3 py-2 pl-10 pr-10 border rounded-md focus:outline-none focus:ring-2
                      ${errors.password ? 'border-red-500 focus:ring-red-500' : 'border-gray-300 focus:ring-blue-500'}`}
                                        placeholder="Enter your password"
                                    />
                                    <button
                                        type="button"
                                        onClick={() => setShowPassword(!showPassword)}
                                        className="absolute right-3 top-1/2 transform -translate-y-1/2 text-blue-500"
                                    >
                                        {showPassword ? <EyeOff size={20} /> : <Eye size={20} />}
                                    </button>
                                </div>
                                {errors.password && (
                                    <div className="text-red-500 text-sm mt-1 flex items-center">
                                        <AlertCircle className="mr-2 h-4 w-4" />
                                        {errors.password}
                                    </div>
                                )}
                            </div>

                            {/* Remember Me & Forgot Password */}
                            <div className="flex justify-between items-center">
                                <div className="flex items-center">
                                    <input
                                        type="checkbox"
                                        id="remember"
                                        checked={rememberMe}
                                        onChange={() => setRememberMe(!rememberMe)}
                                        className="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300 rounded"
                                    />
                                    <label htmlFor="remember" className="ml-2 block text-sm text-gray-900">
                                        Remember me
                                    </label>
                                </div>
                                <a href="#" className="text-sm text-blue-600 hover:text-blue-500">
                                    Forgot password?
                                </a>
                            </div>

                            {/* Submit Button */}
                            <button
                                type="submit"
                                className="w-full bg-blue-600 text-white py-2 rounded-md hover:bg-blue-700 transition duration-300 mt-4"
                            >
                                Sign In
                            </button>

                            {/* Toggle to Register */}
                            <div className="text-center mt-4">
                                <span className="text-sm text-gray-600">
                                    Don't have an account?
                                    <button
                                        type="button"
                                        onClick={toggleRegistration}
                                        className="text-blue-600 hover:text-blue-500 font-medium ml-1"
                                    >
                                        Register
                                    </button>
                                </span>
                            </div>
                        </form>
                    </div>

                    {/* Message Panel (Sliding) */}
                    <div className={`
            w-1/2 bg-blue-600 relative transition-all duration-700 ease-in-out
            ${isRegistering
                            ? '-translate-x-full opacity-100'
                            : 'translate-x-0 opacity-100'
                        }
          `}>
                        <img
                            src="https://i0.wp.com/visualsculptors.com/wp-content/uploads/2024/05/139-scaled.jpg?fit=640%2C640&ssl=1"
                            alt="Skill Matrix"
                            className="w-full h-full object-cover opacity-70"
                        />
                        <div className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 text-center text-white">
                            <h1 className="text-3xl font-bold mb-4">Welcome to</h1>
                            <h2 className="text-4xl font-extrabold">Skill Matrix Management</h2>
                            <p className="mt-4 text-lg">
                                {isRegistering
                                    ? "Join our community and unlock your potential!"
                                    : "Manage your skills with precision and ease"}
                            </p>
                        </div>
                    </div>
                </div>

                {/* Registration Panel */}
                <div className={`
          absolute inset-0 z-20 flex transition-all duration-700 ease-in-out
          ${isRegistering
                        ? 'translate-x-0'
                        : 'translate-x-full'
                    }
        `}>
                    {/* Registration Form */}
                    <div className={`
            w-1/2 bg-white p-12 flex flex-col justify-center transition-all duration-700 ease-in-out
            ${isRegistering
                            ? 'translate-x-0'
                            : 'translate-x-full'
                        }
          `}>
                        <h2 className="text-2xl font-bold mb-6 text-center text-blue-800">
                            Create Account
                        </h2>

                        <form onSubmit={handleSubmit} className="space-y-4">
                            {/* Username Input */}
                            <div>
                                <label htmlFor="username" className="block text-sm font-medium text-gray-700 mb-2">
                                    Username
                                </label>
                                <div className="relative">
                                    <User className="absolute left-3 top-1/2 transform -translate-y-1/2 text-blue-500" size={20} />
                                    <input
                                        type="text"
                                        id="username"
                                        value={username}
                                        onChange={(e) => setUsername(e.target.value)}
                                        className={`w-full px-3 py-2 pl-10 border rounded-md focus:outline-none focus:ring-2 
                      ${errors.username ? 'border-red-500 focus:ring-red-500' : 'border-gray-300 focus:ring-blue-500'}`}
                                        placeholder="Choose a username"
                                    />
                                </div>
                                {errors.username && (
                                    <div className="text-red-500 text-sm mt-1 flex items-center">
                                        <AlertCircle className="mr-2 h-4 w-4" />
                                        {errors.username}
                                    </div>
                                )}
                            </div>

                            {/* Email Input */}
                            <div>
                                <label htmlFor="email" className="block text-sm font-medium text-gray-700 mb-2">
                                    Email
                                </label>
                                <div className="relative">
                                    <Mail className="absolute left-3 top-1/2 transform -translate-y-1/2 text-blue-500" size={20} />
                                    <input
                                        type="email"
                                        id="email"
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                        className={`w-full px-3 py-2 pl-10 border rounded-md focus:outline-none focus:ring-2 
                      ${errors.email ? 'border-red-500 focus:ring-red-500' : 'border-gray-300 focus:ring-blue-500'}`}
                                        placeholder="Enter your email"
                                    />
                                </div>
                                {errors.email && (
                                    <div className="text-red-500 text-sm mt-1 flex items-center">
                                        <AlertCircle className="mr-2 h-4 w-4" />
                                        {errors.email}
                                    </div>
                                )}
                            </div>

                            {/* Password Input */}
                            <div>
                                <label htmlFor="password" className="block text-sm font-medium text-gray-700 mb-2">
                                    Password
                                </label>
                                <div className="relative">
                                    <Lock className="absolute left-3 top-1/2 transform -translate-y-1/2 text-blue-500" size={20} />
                                    <input
                                        type={showPassword ? "text" : "password"}
                                        id="password"
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        className={`w-full px-3 py-2 pl-10 pr-10 border rounded-md focus:outline-none focus:ring-2
                      ${errors.password ? 'border-red-500 focus:ring-red-500' : 'border-gray-300 focus:ring-blue-500'}`}
                                        placeholder="Enter your password"
                                    />
                                    <button
                                        type="button"
                                        onClick={() => setShowPassword(!showPassword)}
                                        className="absolute right-3 top-1/2 transform -translate-y-1/2 text-blue-500"
                                    >
                                        {showPassword ? <EyeOff size={20} /> : <Eye size={20} />}
                                    </button>
                                </div>
                                {errors.password && (
                                    <div className="text-red-500 text-sm mt-1 flex items-center">
                                        <AlertCircle className="mr-2 h-4 w-4" />
                                        {errors.password}
                                    </div>
                                )}
                            </div>

                            {/* Submit Button */}
                            <button
                                type="submit"
                                className="w-full bg-blue-600 text-white py-2 rounded-md hover:bg-blue-700 transition duration-300 mt-4"
                            >
                                Register
                            </button>

                            {/* Toggle to Sign In */}
                            <div className="text-center mt-4">
                                <span className="text-sm text-gray-600">
                                    Already have an account?
                                    <button
                                        type="button"
                                        onClick={toggleRegistration}
                                        className="text-blue-600 hover:text-blue-500 font-medium ml-1"
                                    >
                                        Sign In
                                    </button>
                                </span>
                            </div>
                        </form>
                    </div>

                    {/* Message Panel */}
                    <div className={`
            w-1/2 bg-blue-600 relative transition-all duration-700 ease-in-out
            ${isRegistering
                            ? 'translate-x-0 opacity-100'
                            : 'translate-x-full opacity-0'
                        }
          `}>
                        <img
                            src="https://i.pinimg.com/736x/78/97/f3/7897f38ede7c84b13aa6a44a98407099.jpg"
                            alt="Skill Matrix"
                            className="w-full h-full object-cover opacity-70"
                        />
                        <div className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 text-center text-white">
                            <h1 className="text-3xl font-bold mb-4">Create Account</h1>
                            <h2 className="text-4xl font-extrabold">Get Started</h2>
                            <p className="mt-4 text-lg">
                                Join our community and unlock your potential!
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default SignInPage;