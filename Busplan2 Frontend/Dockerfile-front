FROM node:alpine
WORKDIR 'Busplan2 Frontend/app'

COPY package.json .
RUN npm install
COPY . .
CMD ["npm", "start"]