function validateRequest(httpRequest) {
    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const uriPattern = /^\*$|^([A-Za-z\d\.]+)$/;
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const messagePattern = /^[^<>\\&'"]*$/;

    if (!httpRequest.hasOwnProperty('method')
        || !methods.includes(httpRequest['method'])) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!httpRequest.hasOwnProperty('uri') || !uriPattern.test(httpRequest['uri'])) {
        throw new Error('Invalid request header: Invalid URI');
    }

    if (!httpRequest.hasOwnProperty('version')
        || !versions.includes(httpRequest['version'])) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (!httpRequest.hasOwnProperty('message')
        || !messagePattern.test(httpRequest['message'])) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return httpRequest;
}

try {
    console.log(validateRequest(
        {
            method: 'GET',
            uri: 'svn.public.catalog',
            version: 'HTTP/1.1',
            message: ''
        }
    ));
} catch (error) {
    console.log(error.message);
}

try {
    console.log(validateRequest(
        {
            method: 'OPTIONS',
            uri: 'git.master',
            version: 'HTTP/1.1',
            message: '-recursive'          
        }
    ));
} catch (error) {
    console.log(error.message);
}






