  const randomBetween = (min: number, max: number): number => {
    return Math.random() * (max - min) + min;
  };

  class Vector2 {
    public x: number;
    public y: number;

    constructor(x: number = 0, y: number = 0) {
      this.x = x;
      this.y = y;
    }

    public add(other: Vector2): void {
      this.x += other.x;
      this.y += other.y;
    }

    public sub(other: Vector2): void {
      this.x -= other.x;
      this.y -= other.y;
    }

    public mul(other: Vector2|number): void {
      this.x *= other instanceof Vector2 ? other.x : other;
      this.y *= other instanceof Vector2 ? other.y : other;
    }

    public div(other: Vector2|number): void {
      this.x /= other instanceof Vector2 ? other.x : other;
      this.y /= other instanceof Vector2 ? other.y : other;
    }

    public magnitude(): number {
      return Math.sqrt(this.magnitudeSq());
    }

    public magnitudeSq(): number {
      return this.x * this.x + this.y * this.y;
    }

    public normalize(): void {
      const mag: number = this.magnitude();
      if (mag === 0) {
        return;
      }

      this.mul(1 / mag);
    }

    public limit(max: number): void {
      const magSq: number = this.magnitudeSq();
      if (magSq < max * max) {
        return;
      }

      this.div(Math.sqrt(magSq));
      this.mul(max);
    }
  }

  class Particle {
    private velocity: Vector2 = new Vector2();
    private size: number = randomBetween(1, 3);
    public position: Vector2 = new Vector2();

    constructor(x: number, y: number) {
      this.position.x = x;
      this.position.y = y;
    }

    public update(mouse: Vector2): void {
      const vector: Vector2 = new Vector2(mouse.x, mouse.y);
      vector.sub(this.position);
      vector.normalize();
      vector.mul(0.6);
      this.velocity.add(vector);
      this.position.add(this.velocity);
      vector.mul(0);
      this.velocity.limit(10);
    }

    public render(ctx: CanvasRenderingContext2D): void {
      ctx.beginPath();
      ctx.arc(this.position.x, this.position.y, this.size, 0, Math.PI * 2);
      ctx.fillStyle = 'rgba(248, 113, 113, 0.4)';
      ctx.fill();
    }
  }

  export class Hero {
    public readonly canvas: HTMLCanvasElement;
    public readonly parent: HTMLElement;
    private ctx!: CanvasRenderingContext2D;
    private readonly _mouse: Vector2;
    private readonly _particles: Particle[];
    private readonly _observer: ResizeObserver;

    constructor(canvas: HTMLCanvasElement) {
      this.canvas = canvas;
      this.parent = canvas.parentElement!;
      this._mouse = new Vector2(this.parent.clientWidth / 2, this.parent.clientHeight / 4);
      this._particles = Array.from({ length: 1000 }, () => {
        const angle: number = Math.random() * Math.PI * 2;
        const radius: number = randomBetween(0, 1080);
    
        return new Particle(
          this._mouse.x + Math.cos(angle) * radius,
          this._mouse.y + Math.sin(angle) * radius
        );
      });

      // Bit experimental, but seems to be implemented in every major browser since +-March 2022.
      // https://caniuse.com/resizeobserver
      this._observer = new ResizeObserver(this.resizeCanvas.bind(this));
    }

    public start(): void {
      this.ctx = this.canvas.getContext('2d')!;
      let frame: number;

      const loop = () => {
        frame = requestAnimationFrame(loop);

        this.render(frame);

        return () => {
          cancelAnimationFrame(frame);
        };
      };

      this.subscribe();
      this.resizeCanvas();

      frame = requestAnimationFrame(loop);
    }

    private subscribe(): void {
      this._observer.observe(this.parent);
      window.addEventListener('resize', this.resizeCanvas.bind(this));
      window.addEventListener('mousemove', this.pointerMove.bind(this));
    }

    private render(_: number): void {
      this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
      for (const particle of this._particles) {
        particle.update(this._mouse);
        particle.render(this.ctx);
      }
    }

    private pointerMove(event: MouseEvent): void {
      let x: number = event.pageX - this.canvas.offsetLeft;
      let y: number = event.pageY - this.canvas.offsetTop;
      if (x < 0 || x > this.canvas.width) {
        x = this.canvas.width / 2;
      }
      if (y < 0) {
        y = this.canvas.height / 4;
      }
      if (y > this.canvas.height) {
        y = this.canvas.height - this.canvas.offsetTop;
      }

      this._mouse.x = x;
      this._mouse.y = y;
    };
  
    private resizeCanvas(): void {
      this.canvas.width = this.parent.clientWidth;
      this.canvas.height = this.parent.clientHeight;
    };
  }