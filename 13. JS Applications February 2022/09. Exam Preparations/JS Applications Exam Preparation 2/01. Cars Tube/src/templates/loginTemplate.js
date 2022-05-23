import { html } from './../../node_modules/lit-html/lit-html.js';

export const loginTemplate = (loginHandler) => html`
<section id="login">
    <div class="container">
        <form id="login-form" action="#" method="post" @submit=${loginHandler}>
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>
`;